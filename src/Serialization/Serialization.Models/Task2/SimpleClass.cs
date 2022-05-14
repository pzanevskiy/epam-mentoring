using System;
using System.Runtime.Serialization;

namespace Serialization.Models.Task2
{
    [Serializable]
    public class SimpleClass : ISerializable
    {
        public SimpleClass()
        {
            
        }

        public string SimpleString { get; set; }

        public int SimpleInt { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("customSimpleString", SimpleString, typeof(string));
            info.AddValue("customSimpleInt", SimpleInt, typeof(int));
        }

        public SimpleClass(SerializationInfo info, StreamingContext context)
        {
            SimpleString = (string) info.GetValue("customSimpleString", typeof(string));
            SimpleInt = (int) info.GetValue("customSimpleInt", typeof(int));
        }
    }
}
