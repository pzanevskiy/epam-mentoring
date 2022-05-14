using System.Collections.Generic;

namespace Serialization.Models.Task1
{
    public static class StaticData
    {
        public static Department Department = new Department
        {
            DepartmentName = ".Net",
            Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeName = "Pavel"
                },
                new Employee
                {
                    EmployeeName = "Ivan"
                }
            }
        };
    }
}
