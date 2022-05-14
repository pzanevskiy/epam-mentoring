using System;
using Serialization.Models.Task1;

namespace Serialization.DeepCloning
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = StaticData.Department;

            var clonedDepartment = (Department) department.Clone();

            Console.WriteLine($"Are objects the same? {department.Equals(clonedDepartment)}");
        }
    }
}
