using Serialization.Models.Task1;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization.Xml
{
    class Program
    {
        private const string FileName = "department.xml";

        static void Main(string[] args)
        {
            var department = StaticData.Department;
            Serialize(department);

            var deserializedDepartment = Deserialize();
            ShowDepartment(deserializedDepartment);
        }

        private static void Serialize(Department department)
        {
            var xmlSerializer = new XmlSerializer(typeof(Department));
            using var stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            xmlSerializer.Serialize(stream, department);
        }

        private static Department Deserialize()
        {
            var xmlSerializer = new XmlSerializer(typeof(Department));
            using var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var department = (Department)xmlSerializer.Deserialize(stream);
            return department;
        }

        private static void ShowDepartment(Department department)
        {
            Console.WriteLine(department.DepartmentName);

            foreach (var employee in department.Employees)
            {
                Console.WriteLine(employee.EmployeeName);
            }
        }
    }
}
