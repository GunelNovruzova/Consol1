using NewConsoleProject.Models;
using NewConsoleProject.Service;
using System;
using System.Collections.Generic;

namespace ConsoleProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.WriteLine("-------------------------Human Resource Management---------------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyatin qarsisindaki nomreni daxil edin:");
                Console.WriteLine(" 1 -Departamenet yaratmaq ");
                Console.WriteLine(" 2 -Departameantlerin siyahisini gostermek ");
                Console.WriteLine(" 3 - Departmanetde deyisiklik etmek ");
                Console.WriteLine(" 4 - Iscilerin siyahisini gostermek ");
                Console.WriteLine(" 5 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine(" 6 - Isci elave etmek");
                Console.WriteLine(" 7 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine(" 8 - Departamentden isci silinmesi");
                Console.Write("Emeliyyatin nomresini daxil edin");

                string choose = Console.ReadLine();
                double chooseNum;
                double.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                       break;
                    case 2:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartments(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployee(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetEmployeesbyDepartment(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        Console.Clear();
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 8:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil et");
                        break;
                }

            } while (true);

        }

        public static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length > 0)
            {
                foreach (Department item in humanResourceManager.departments)
                {
                    Console.WriteLine($"{item}\nMaas ortalamasi:  { item.CalcAverageSalary()}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sistemde Department movcud deyil. Once department yaradin");
            }
        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
        checkN:
            Console.WriteLine("Departmentin adini daxil edin");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkN;

            }

            Console.WriteLine("Isci sayini daxil edin");
        checkab:
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            if (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum < 1)
            {
                Console.WriteLine("Duzgun daxil et");
                goto checkab;
            }
            Console.WriteLine("Maas limitini daxil et");
        checksd:
            string SalaryLimit = Console.ReadLine();
            int SalaryLimitNum = 0;
            if (!int.TryParse(SalaryLimit, out SalaryLimitNum) || SalaryLimitNum < 250)
            {
                Console.WriteLine("Duzgun daxil et");
                goto checksd;
            }

            humanResourceManager.AddDepartment(name, WorkerLimitNum, SalaryLimitNum);
        }
        static void EditDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length <= 0)
            {
                Console.WriteLine("Once Department yaradin:");
                return;

            }
            Console.WriteLine("Departmenlerin siyahisi");
            foreach (Department item in humanResourceManager.departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("________________________");
            }
            Console.WriteLine("Deyisiklik edeceyiniz departmentin adini daxil edin");

            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                foreach (Department item in humanResourceManager.departments)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("Deyisikliyi daxil edin");
                        string newname = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            item.Name = newname;
                            Console.Clear();
                            Console.WriteLine("Deyisiklik qeyd edildi");
                        }

                    }

                }
            }
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length <= 0)
            {
                Console.WriteLine("Once department daxil edin");
                return;
            }
            Console.WriteLine("Elave etmek istediyiniz department adini daxil edin");
        checkDN:
            string departmentname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkDN;
            }
            string fullname = string.Empty;
            string position = string.Empty;
            double salary = 0;
            foreach (Department item in humanResourceManager.departments)
            {
                if (item.Name.ToLower() == departmentname.ToLower())
                {
                    if (item.WorkerLimit <= item.EmpCounter())
                    {
                        Console.WriteLine("Departmentde yer yoxdur");
                        return;
                    }
                }
            }

        checkFN:
            Console.WriteLine("Iscinin ad soyadini daxil edin");
            fullname = Console.ReadLine();
            string[] fn = fullname.Split(' ');
            if (string.IsNullOrWhiteSpace(fullname) || fn.Length < 2)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkFN;

            }
            Console.WriteLine("Iscinin vezifesini daxil edin");
        checkP:
            position = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(position) || position.Length < 2)
            {
                Console.WriteLine("Duzgun daxil edin");
                position = Console.ReadLine();
                goto checkP;
            }
            Console.WriteLine("Maasi daxil edin");
        checkS:
            string Salary = Console.ReadLine();
            //double salary=0;
            if (!double.TryParse(Salary, out salary) || salary < 250)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkS;
            }
            foreach (Department item2 in humanResourceManager.departments)
            {
                if (item2.Name.ToLower() == departmentname.ToLower())
                {
                    while (item2.SalaryLimit < item2.SalaryCounter() + salary)
                    {
                        Console.WriteLine("Maas limiti dolmusdur");
                        Console.WriteLine("Meblegi duzgun daxil edin");
                        goto checkS;
                    }

                }
                break;

            }
            humanResourceManager.AddEmployee(fullname, position, salary, departmentname);
        }
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length <= 0)
            {
                Console.WriteLine("Once department yaradin");

            }
            foreach (Department item in humanResourceManager.departments)
            {

                if (item.Employees.Length < 0)
                {
                    Console.WriteLine("Once isci daxil edin");
                    return;
                }

                foreach (Employee item2 in item.Employees)
                {

                    Console.WriteLine("Deyisiklik edeciyiniz iscinin nomresini daxil edin");
                checkNO:
                    string no = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(no))
                    {
                        Console.WriteLine("Iscinin nomresini duzgun daxil edin");
                        goto checkNO;
                    }
                    foreach (Department item3 in humanResourceManager.departments)
                    {
                        string newposition = string.Empty;
                        string newsalary = string.Empty;
                        //double newsalaryNum = 0;
                        foreach (Employee item4 in item.Employees)
                        {
                            if (item.Employees != null)
                            {
                                if (item4.No.ToLower() == no.ToLower())
                                {
                                    Console.Clear();
                                    Console.WriteLine(item4);
                                cases:
                                    Console.WriteLine("Deyisiklik etmek istediniz emeliyyatin nomresini daxil edin");
                                    Console.WriteLine("1:Maasi deyismek ucun");
                                    Console.WriteLine("2:Vezifeni deyismek ucun");

                                checkEmp:
                                    string Emp = Console.ReadLine();
                                    int EmpNum = 0;
                                    if (!int.TryParse(Emp, out EmpNum))
                                    {
                                        Console.WriteLine("Duzgun daxil edin");
                                        goto checkEmp;
                                    }
                                    switch (EmpNum)
                                    {
                                        case 1:
                                            Console.WriteLine("Iscinin yeni maasini daxil edin");

                                        checknewsalary:

                                            newsalary = Console.ReadLine();
                                            int newsalaryNum = 0;
                                            if (!int.TryParse(newsalary, out newsalaryNum))
                                            {
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto checknewsalary;
                                            }
                                            item2.Salary = newsalaryNum;
                                            Console.WriteLine("Maas deyisikliyi qeyde alindi");
                                            break;
                                        case 2:
                                            Console.WriteLine("Iscinin yeni vezifesini daxil edin");

                                        checkPosition:

                                            newposition = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(newposition) || newposition.Length < 2)
                                            {
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto checkPosition;
                                            }
                                            item2.Position = newposition;
                                            Console.WriteLine("Vezife deyisikliyi qeyde alindi");
                                            goto cases;

                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

        }
        static void GetEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length > 0)
            {
                foreach (Department item in humanResourceManager.departments)
                {
                    if (item.Employees.Length > 0)
                    {
                        Console.WriteLine("Iscilerin siyahisi");
                        Console.WriteLine("______");
                        foreach (Employee item2 in item.Employees)
                        {
                            Console.WriteLine($"{item2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departmentde isci movcud deyil");
                    }
                }
            }
            else
            {
                Console.WriteLine("Once isci elave edin");
                return;
            }


        }
        static void GetEmployeesbyDepartment(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length <= 0)
            {
                Console.WriteLine("Department movcud deyil");
                return;
            }
            foreach (Department item in humanResourceManager.departments)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Departmentin adini daxil edin");
        checkdepartmentname:
            string departmentname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkdepartmentname;
            }
            foreach (Department item1 in humanResourceManager.departments)
            {
                if (item1.Name.ToLower() == departmentname.ToLower())
                {
                    foreach (Employee item2 in item1.Employees)
                    {
                        if (item2 != null)
                        {
                            Console.WriteLine(item2);
                        }
                    }
                }
                break;
            }

        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            int count = 0;
            foreach (Department item in humanResourceManager.departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item.Employees.Length < 0)
                    {
                        Console.WriteLine("Once isci daxil edin");
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine("Iscilerin siyahisi");
            Console.WriteLine("---------------------");
            foreach (Department item in humanResourceManager.departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------");
            }
            Console.WriteLine("Departmentin adini daxil edin");
        checkDN:
            string deparmentname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(deparmentname) || deparmentname.Length < 2)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto checkDN;
            }
            string Emp = Console.ReadLine();
            foreach (Department item in humanResourceManager.departments)
            {
                if (item.Name.ToLower() == deparmentname.ToLower())
                {
                    int empcount = 0;
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null)
                        {
                            empcount++;
                            Console.WriteLine(item2);
                        }
                    }
                }
                Console.WriteLine("Iscinin nomresini daxil edin");
            checkEN:
                string EmpNo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(EmpNo))
                {
                    Console.WriteLine("Duzgun daxil edin");
                    goto checkEN;
                }
                bool result = false;
                for (int i = 0; i < item.Employees.Length; i++)
                {
                    if (item.Employees[i] != null)
                    {
                        if (item.Employees[i].No.ToLower() == EmpNo.ToLower())
                        {
                            item.Employees[i] = null;
                            result = true;
                            break;
                        }
                    }
                }
                if (result)
                {
                    Console.Clear();
                    Console.WriteLine("Isci silindi");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Isci movcud deyil");

                }
                break;
            }











        }

    }
}
