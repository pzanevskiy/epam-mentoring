using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Serialization.Models.Task1;

namespace Serialization.Binary
{
    class Program
    {
        private const string FileName = "department.bin";

        static void Main(string[] args)
        {
            var department = StaticData.Department;
            Serialize(department);

            var deserializedDepartment = Deserialize();
            ShowDepartment(deserializedDepartment);
        }

        private static void Serialize(Department department)
        {
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            binaryFormatter.Serialize(stream, department);
        }

        private static Department Deserialize()
        {
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var department = (Department) binaryFormatter.Deserialize(stream);
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
