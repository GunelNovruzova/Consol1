using NewConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
       public Department[] departments { get; }
        void AddDepartment(string name, int workerlimit, double salarylimit);
        Department[] GetDepartments();
        void GetEmployees(string no, string fullname, string departmentname, double salary);
       void EditDepartments(string name, string newname);
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string no, string departmentName);
        void EditEmployee(string no, string fullname, string position, double salary);
        void GetEmployeesByDepatment(string departmentname);

    }
}
