using System;
using System.Collections.Generic;
using System.Text;

namespace NewConsoleProject.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public Employee[] Employees = { };
        public static int Count = 0;
    
        public Department(string name, int workerlimit, double salarylimit)
        {
            Employees = new Employee[0];
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;


            if (WorkerLimit <= 1)
            {
                Console.WriteLine("Isci sayini duzgun daxil edin");
                return;
            }
            if (SalaryLimit <= 250)
            {
                Console.WriteLine("Maas 250-den asagi ola bilmez");
                return;
            }
        }
        public double CalcAverageSalary()
        {
            double TotalSalary = 0;
            int count = 0;
            if (Employees.Length <= 0)
            {
                return 0;
            }
            else
            {
                foreach (Employee item in Employees)
                {
                    TotalSalary += item.Salary;
                    count++;
                }
                return TotalSalary / count;
            }

        }
        public override string ToString()
        {
            return $"Department adi: {Name}\nIshci sayi: {WorkerLimit}\nMaash Limiti: {SalaryLimit}";
        }
    }
}
