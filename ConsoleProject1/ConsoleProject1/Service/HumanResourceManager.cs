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
        public bool Checkname(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (Char.IsUpper(str[0]))
                {
                    foreach (var chr in str)
                    {
                        if (Char.IsLetter(chr) == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(fullname,position,salary,departmentName);

            foreach (Department item in _departments)
            {
                if (employee.DepartmentName.ToLower() == item.Name.ToLower())
                {
                    //item.Employees = new Employee[0];
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                }
               
            }
        }

        public void EditDepartments(string name, string newname)
        {
            foreach (Department item in departments)
            {
                if (item.Name.ToLower() == name)
                {
                    item.Name = newname;
                    Console.WriteLine("Departament adinda deyisiklik edildi.");
                    break;
                }
            }
        }

        public void EditEmployee(string no, string fullname, string position, double salary)
        {
            Employee employee = null;
            foreach (Department item in _departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2.No == no)
                    {
                        employee = item2;
                        break;
                    }
                    employee.Fullname = fullname;
                    employee.Position = position;
                    employee.Salary = salary;
                }
            }

        }

        public Employee[] GetEmployeesbyDepartment(string name)

        {
            Employee[] arr = new Employee[0];
            foreach (Department item in _departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2.DepartmentName.ToLower()==name.ToLower())
                    {
                        Console.WriteLine(item2);
                    }
                }
            }
            return arr;
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
            throw new NotImplementedException();
        }
    }
}
