using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Serialization.Models.Task1
{
    [Serializable]
    [XmlRoot("CustomDepartment")]
    public class Department : ICloneable
    {
        [XmlElement("CustomDepartmentName")]
        [JsonPropertyName("CustomDepartmentName")]
        public string DepartmentName { get; set; }

        [XmlArray("CustomEmployees")]
        [XmlArrayItem("CustomEmployee")]
        [JsonPropertyName("CustomEmployees")]
        public List<Employee> Employees { get; set; }

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
