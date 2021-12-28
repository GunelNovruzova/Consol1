using System;
using System.Collections.Generic;
using System.Text;

namespace NewConsoleProject.Models
{
    class Employee
    {
        private static int Count = 1000;
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }

        public Employee(string fullname, string position, double salary, string departmentName)
        {
            if (position.Length < 2)
            {
                Console.WriteLine("Daxil etdiyiniz position adi sehvdir");
            }

            No += departmentName.Substring(0, 2) + Count;
            Count++;
            Salary = salary;
            Fullname = fullname;
            Position = position;
            DepartmentName = departmentName;
            
        }

              public override string ToString()
        {
            return $"nomresi: {No}\nFullname: {Fullname}\n/*Position: {Position}*/\nsalary: {Salary}";

        }

    
    }
}
