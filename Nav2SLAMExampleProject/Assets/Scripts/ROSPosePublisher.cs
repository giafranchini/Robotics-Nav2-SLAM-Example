using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Robotics.Core;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Std;
using RosMessageTypes.Geometry;
using RosMessageTypes.BuiltinInterfaces;


public class ROSPosePublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "goal_update";
    public float publishMessageFrequency = 0.5f;
    public List<string> m_GlobalFrameIds = new List<string> { "map", "odom" };
    public GameObject obj;
    public bool goal2D = true; 
    private float timeElapsed;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PoseStampedMsg>(topicName);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            Vector3 objPos = obj.transform.position;
            Quaternion objRot = obj.transform.rotation;

            if (goal2D)
            {
                objPos.y = 0;
                Vector3 objRotEuler = objRot.eulerAngles;
                objRotEuler.x = 0;
                objRotEuler.z = 0;
                objRot = Quaternion.Euler(objRotEuler);
            }

            PoseStampedMsg objPose = new PoseStampedMsg(
                new HeaderMsg(new TimeStamp(Clock.time), m_GlobalFrameIds.Last()),
                new PoseMsg(
                    objPos.To<FLU>(),
                    objRot.To<FLU>()
                )
            );

            ros.Publish(topicName, objPose);

            timeElapsed = 0;
        }
    }
}
