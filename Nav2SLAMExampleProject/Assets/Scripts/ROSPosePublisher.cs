using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using RosMessageTypes.Geometry;
using RosMessageTypes.BuiltinInterfaces;


public class ROSPosePublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "goal_update";

    // The game object
    public GameObject Cube;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PoseStampedMsg>(topicName);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            PoseStampedMsg avatarPose = new PoseStampedMsg(
                new HeaderMsg(new TimeMsg(), "map"),
                new PoseMsg(
                    new PointMsg(Cube.transform.position.x, Cube.transform.position.y, Cube.transform.position.z),
                    new QuaternionMsg(Cube.transform.rotation.x, Cube.transform.rotation.y, Cube.transform.rotation.z, Cube.transform.rotation.w)
                )
            );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Publish(topicName, avatarPose);

            timeElapsed = 0;
        }
    }
}
