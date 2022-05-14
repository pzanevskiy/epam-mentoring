using Serialization.Models.Task1;
using System;
using System.IO;
using System.Text.Json;

namespace Serialization.Json
{
    class Program
    {
        private const string FileName = "department.json";

        static void Main(string[] args)
        {
            var department = StaticData.Department;
            Serialize(department);

            var deserializedDepartment = Deserialize();
            ShowDepartment(deserializedDepartment);
        }

        private static void Serialize(Department department)
        {
            var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(department, jsonSerializerOptions);
            File.WriteAllText(FileName, jsonString);
        }

        private static Department Deserialize()
        {
            var jsonString = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<Department>(jsonString);
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
