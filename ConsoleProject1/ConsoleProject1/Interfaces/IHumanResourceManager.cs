using NewConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] departments { get; }
        void AddDepartment(string name, int workerlimit, double salarylimit);
        //Department[] GetDepartments();
        Employee[] GetEmployeesbyDepartment(string name);
        void EditDepartments(string name, string newname);
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string no, string departmentName);
        void EditEmployee(string no, string fullname, string position, double salary);


    }
}
