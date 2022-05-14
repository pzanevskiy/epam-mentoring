using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Serialization.Models.Task1
{
    [Serializable]
    public class Employee : ICloneable
    {
        [XmlElement("CustomEmployeeName")]
        [JsonPropertyName("CustomEmployeeName")]
        public string EmployeeName { get; set; }

        public object Clone()
        {
            using var stream = new MemoryStream();
            if (GetType().IsSerializable)
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
            return null;
        }
    }
}
