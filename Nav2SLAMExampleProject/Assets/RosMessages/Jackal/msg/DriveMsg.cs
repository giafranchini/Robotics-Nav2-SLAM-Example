//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Jackal
{
    [Serializable]
    public class DriveMsg : Message
    {
        public const string k_RosMessageName = "jackal_msgs/Drive";
        public override string RosMessageName => k_RosMessageName;

        //  This message represents a low-level motor command to Jackal.
        //  Command units dependent on the value of this field
        public const sbyte MODE_VELOCITY = 0; //  velocity command (rad/s of wheels)
        public const sbyte MODE_PWM = 1; //  proportion of full voltage command [-1.0..1.0]
        public const sbyte MODE_EFFORT = 2; //  torque command (Nm)
        public const sbyte MODE_NONE = -1; //  no control, commanded values ignored.
        public sbyte mode;
        //  Units as above, +ve direction propels chassis forward.
        public const sbyte LEFT = 0;
        public const sbyte RIGHT = 1;
        public float[] drivers;

        public DriveMsg()
        {
            this.mode = 0;
            this.drivers = new float[2];
        }

        public DriveMsg(sbyte mode, float[] drivers)
        {
            this.mode = mode;
            this.drivers = drivers;
        }

        public static DriveMsg Deserialize(MessageDeserializer deserializer) => new DriveMsg(deserializer);

        private DriveMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.mode);
            deserializer.Read(out this.drivers, sizeof(float), 2);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.mode);
            serializer.Write(this.drivers);
        }

        public override string ToString()
        {
            return "DriveMsg: " +
            "\nmode: " + mode.ToString() +
            "\ndrivers: " + System.String.Join(", ", drivers.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}