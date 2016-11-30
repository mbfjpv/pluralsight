using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Generics.ConsoleApp
{
    class Program
    {
        class Employee
        {
            public string Name { get; set; }
        }

        class EmployeeComparer : IEqualityComparer<Employee>, 
                                    IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return String.Compare(x.Name, y.Name);
            }

            public bool Equals(Employee x, Employee y)
            {
                return String.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Employee obj)
            {
                return obj.Name.GetHashCode();
            }


        }

        class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
        {
            public DepartmentCollection Add(string departmentName, Employee employee)
            {
                if(!ContainsKey(departmentName))
                {
                    Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
                }
                this[departmentName].Add(employee);
                return this;
            }
        }

        static void Main(string[] args)
        {
            //EmployeeTest1();
            EmployeeTest2();
        }

        private static void EmployeeTest1()
        {
            var departments = new SortedDictionary<string, SortedSet<Employee>>();

            departments.Add("Sales", new SortedSet<Employee>(new EmployeeComparer()));
            departments["Sales"].Add(new Employee { Name = "Scott" });
            departments["Sales"].Add(new Employee { Name = "Dani" });
            departments["Sales"].Add(new Employee { Name = "Dani" });

            departments.Add("Engineering", new SortedSet<Employee>(new EmployeeComparer()));
            departments["Engineering"].Add(new Employee { Name = "Scott" });
            departments["Engineering"].Add(new Employee { Name = "Alex" });
            departments["Engineering"].Add(new Employee { Name = "Dani" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach(var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
            Console.ReadLine();
        }

        private static void EmployeeTest2()
        {
            var departments = new DepartmentCollection();

            departments.Add("Sales", new Employee { Name = "Scott" })
                        .Add("Sales",new Employee { Name = "Dani" })
                        .Add("Sales",new Employee { Name = "Dani" });
            departments.Add("Engineering", new Employee { Name = "Scott" })
                        .Add("Engineering", new Employee { Name = "Alex" })
                        .Add("Engineering", new Employee { Name = "Dani" });


            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
}
