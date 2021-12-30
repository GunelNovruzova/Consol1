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
                Console.WriteLine(" 1.1 -Departamenet yaratmaq ");
                Console.WriteLine(" 1.2 -Departameantlerin siyahisini gostermek ");
                Console.WriteLine(" 1.3 - Departmanetde deyisiklik etmek ");
                Console.WriteLine(" 2.1 - Iscilerin siyahisini gostermek ");
                Console.WriteLine(" 2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine(" 2.3 - Isci elave etmek");
                Console.WriteLine(" 2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine(" 2.5 - Departamentden isci silinmesi");
                Console.Write("Emeliyyatin nomresini daxil edin");

                string choose = Console.ReadLine();
                double chooseNum;
                double.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1.1:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 1.2:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 1.3:
                        Console.Clear();
                        EditDepartments(ref humanResourceManager);
                        break;
                    case 2.1:
                        Console.Clear();
                        GetEmployee(ref humanResourceManager);
                        break;
                    case 2.2:
                        Console.Clear();
                        GetEmployeesbyDepartment(ref humanResourceManager);
                        break;
                    case 2.3:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 2.4:
                        Console.Clear();
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 2.5:
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
            string name;
            bool check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("Departmentin adini daxil edin");
                }
                else
                {
                    Console.WriteLine("Duzgun daxil edin");
                }
                name = Console.ReadLine();
                check = false;
            } while (!humanResourceManager.Checkname(name));
            do
            {
                if (check)
                {
                    Console.WriteLine("Daxil Etdiyiniz Department Movcuddur. Yeniden Yaradin:");
                    name = Console.ReadLine();
                }
                check = true;

            } while (!humanResourceManager.Checkname(name));

            Console.WriteLine("Isci sayini daxil edin");
        checkab:
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum < 1)
            {
                Console.WriteLine("Duzgun daxil et");
                goto checkab;
            }
            Console.WriteLine("Maas limitini daxil et");
        checksd:
            string SalaryLimit = Console.ReadLine();
            int SalaryLimitNum = 0;
            while (!int.TryParse(SalaryLimit, out SalaryLimitNum) || SalaryLimitNum < 250)
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
                Console.WriteLine("Once Daxil edin:");
                return;

            }
            foreach (Department item in humanResourceManager.departments)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("________________________");
            }
            Console.WriteLine("Deyisiklik edeceyiniz departmenti daxil edin");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Duzgun daxil edin");
               
            }
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
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length <= 0)
            {
                Console.WriteLine("Once department daxil edin");
                return;
            }
            Console.WriteLine("Iscinin ad soyadini daxil edin");
            string fullname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Department adini duzgun daxil edin");

            }
            Console.WriteLine("Iscinin vezifesini daxil edin");
            string position = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(position) || position.Length < 2)
            {
                Console.WriteLine("Duzgun daxil edin");
                position = Console.ReadLine();
            }
            Console.WriteLine("Maasi daxil edin");
            string Salary = Console.ReadLine();
            double salary;
            while (!double.TryParse(Salary, out salary) || salary < 250)
            {
                Console.WriteLine("Duzgun daxil edin");

                
            }
            Console.WriteLine("Elave etmek istediyiniz department adini daxil edin");
            string departmentname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun daxil edin");
                
                
            }
            foreach (Department item in humanResourceManager.departments)
            {
                if (item.Name.ToLower() == departmentname.ToLower())
                {
                    Console.WriteLine("Deyishiklik qeyde alindi");
                    break;
                }
                else
                {
                    Console.WriteLine("Department movcud deyil. Department yaradin");
                }
            }
            humanResourceManager.AddEmployee(fullname, position, salary, departmentname);

        }
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department item in humanResourceManager.departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item.Employees.Length < 0)
                    {
                        Console.WriteLine("Once isci daxil edin");
                        return;
                    }
                    Console.WriteLine("Deyisiklik edeciyiniz iscinin nomresini daxil edin");
                checkno:
                    string empno = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(empno))
                    {
                        Console.WriteLine("Nomreni duzgun daxil edin");
                        goto checkno;
                    }
                    else if (item2.No.ToLower() == empno.ToLower())
                    {
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
                                string newsalary = Console.ReadLine();
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
                                string newposition = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(newposition) || newposition.Length < 2)
                                {
                                    Console.WriteLine("Duzgun daxil edin");
                                    goto checkPosition;
                                }
                                item2.Position = newposition;
                                Console.WriteLine("Vezife deyisikliyi qeyde alindi");
                                break;
                        }
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine("Bu nomrede isci movcud deyil");
                        return;
                    }

                }
            } 
           
        }
        static void GetEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.departments.Length>0)
            {
                foreach (Department item in humanResourceManager.departments)
                {
                    if (item.Employees.Length>0)
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
            if (humanResourceManager.departments.Length<=0)
            {
                Console.WriteLine("Department movcud deyil");
                return;
            }
            foreach (Department item in humanResourceManager.departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item.Employees.Length<=0)
                    {
                        Console.Clear();
                        Console.WriteLine("Sistemde isci movcud deyil");
                        return;
                    }
                    Console.WriteLine("Departmentin adini daxil edin");
                checkdepartmentname:
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Duzgun daxil edin");
                        goto checkdepartmentname;
                    }
                    else
                    {
                        Console.WriteLine($"Fullname: {item2.Fullname}\nPosition: {item2.Position}\nNo: {item2.No}\nSalary: {item2.Salary}");
                        return;
                    }
                    
                }
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department item in humanResourceManager.departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    Console.WriteLine("Sileceyiniz iscinin nomresini daxil edin");
                    string no = Console.ReadLine();

                   Console.WriteLine("Sileceyiniz iscinin adini daxil edin");
                   string name = Console.ReadLine();
                    
                   humanResourceManager.RemoveEmployee(no, name);
                }
               
            }
        }
      


    }  
   
}
