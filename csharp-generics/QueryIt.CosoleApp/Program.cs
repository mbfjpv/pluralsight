﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt.CosoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());

            using (IRepository<Employee> employeeRepository
                = new SqlRepository<Employee>(new EmployeeDb()))
            {
                Console.WriteLine("IRepository<Employee>");

                AddEmployees(employeeRepository);
                CountEmployees(employeeRepository);
                QueryEmployees(employeeRepository);
            }
            Console.ReadLine();
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine(employee.Name);
        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count());
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Mahesh" });
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Commit();
        }
    }
}
