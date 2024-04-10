//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Jackal
{
    [Serializable]
    public class FeedbackMsg : Message
    {
        public const string k_RosMessageName = "jackal_msgs/Feedback";
        public override string RosMessageName => k_RosMessageName;

        //  This message represents high-frequency feedback from the MCU,
        //  as necessary to support closed-loop control and thermal monitoring.
        //  Default publish frequency is 50Hz.
        public Std.HeaderMsg header;
        public DriveFeedbackMsg[] drivers;
        //  Commanded control mode, use the TYPE_ constants from jackal_msgs/Drive.
        public sbyte commanded_mode;
        //  Actual control mode. This may differ from the commanded in cases where
        //  the motor enable is off, the motors are in over-current, etc.
        public sbyte actual_mode;

        public FeedbackMsg()
        {
            this.header = new Std.HeaderMsg();
            this.drivers = new DriveFeedbackMsg[2];
            this.commanded_mode = 0;
            this.actual_mode = 0;
        }

        public FeedbackMsg(Std.HeaderMsg header, DriveFeedbackMsg[] drivers, sbyte commanded_mode, sbyte actual_mode)
        {
            this.header = header;
            this.drivers = drivers;
            this.commanded_mode = commanded_mode;
            this.actual_mode = actual_mode;
        }

        public static FeedbackMsg Deserialize(MessageDeserializer deserializer) => new FeedbackMsg(deserializer);

        private FeedbackMsg(MessageDeserializer deserializer)
        {
            this.header = Std.HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.drivers, DriveFeedbackMsg.Deserialize, 2);
            deserializer.Read(out this.commanded_mode);
            deserializer.Read(out this.actual_mode);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.drivers);
            serializer.Write(this.commanded_mode);
            serializer.Write(this.actual_mode);
        }

        public override string ToString()
        {
            return "FeedbackMsg: " +
            "\nheader: " + header.ToString() +
            "\ndrivers: " + System.String.Join(", ", drivers.ToList()) +
            "\ncommanded_mode: " + commanded_mode.ToString() +
            "\nactual_mode: " + actual_mode.ToString();
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