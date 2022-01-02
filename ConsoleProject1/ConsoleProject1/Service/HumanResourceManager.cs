using NewConsoleProject.Interfaces;
using NewConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewConsoleProject.Service
{
    class HumanResourceManager : IHumanResourceManager

    {
        public Department[] departments => _departments;
        private Department[] _departments;
        public HumanResourceManager()
        {
            _departments = new Department[0];
            
        }


        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Department department1 = new Department(name, workerlimit, salarylimit);
            Array.Resize(ref _departments, departments.Length + 1);
            _departments[_departments.Length - 1] = department1;
        }
 
         public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(fullname,position,salary,departmentName);

            foreach (Department item in _departments)
            {
                if (employee.DepartmentName.ToLower() == item.Name.ToLower())
                {
                    
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                    break;
                }
               
            }
        }

        public void EditDepartments(string name, string newname)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    item.Name = newname;
                    Console.WriteLine("Deyisiklik qeyd edildi");
                    break;
                }
            }
        }

        public void EditEmployee(string no, string fullname, string position, double salary)
        {
             foreach (Department item in _departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2!=null && item2.No==no)
                    {
                        item2.Fullname = fullname;
                        item2.Position = position;
                        item2.Salary = salary;

                    }
                   
                }
            }

        }

       public void RemoveEmployee(string no, string departmentName)
        {
            foreach (Department item in _departments)
            {
                for (int i = 0; i < item.Employees.Length; i++)
                {
                    if (item.Employees[i].No==no)
                    {
                        item.Employees = null;
                        return;
                    }
                }
               
            }
        }

        public Department[] GetDepartments()
        {
            if (_departments.Length<0)
            {
                return null;
            }
            return _departments;
        }

        public void GetEmployees(string no, string fullname, string departmentname, double salary)
        {
            Employee[] employees = new Employee[0];

            foreach (Department item in _departments)
            {
                foreach (Employee item2 in employees)
                {
                    if (item2 != null && item2.Fullname == fullname)
                    {
                        Array.Resize(ref employees, employees.Length + 1);
                        employees[employees.Length - 1] = item2;
                        item2.No = no;
                        item2.DepartmentName = departmentname;
                        item2.Salary = salary;
                    }
                }

            }
        }

        public void GetEmployeesByDepatment(string departmentname)
        {
            foreach (Department item in _departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2 != null && item2.DepartmentName.ToLower() == departmentname.ToLower())
                    {
                        item2.DepartmentName = departmentname.ToLower();
                    }
                }
            }
        }
    }
}
