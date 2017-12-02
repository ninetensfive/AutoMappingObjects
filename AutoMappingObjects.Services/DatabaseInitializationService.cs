using AutoMappingObjects.Data;
using AutoMappingObjects.Models;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Services
{
    public class DatabaseInitializationService :IDatabaseInitializationService
    {
        private AutoMappingObjectsContext context;

        public DatabaseInitializationService(AutoMappingObjectsContext context)
        {
            this.context = context;
        }

        public void Reset(bool seed)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if(seed)
            {
                SeedDatabase();
            }
        }

        private void SeedDatabase()
        {
            var employees = new List<Employee>();

            var employee1 = new Employee
            {
                FirstName = "Steve",
                LastName = "Jobbsen",
                Salary = 6000.20M,
                Birthday = DateTime.Parse("1983-04-07")
            };
            
            employees.Add(employee1);

            var employee2 = new Employee
            {
                FirstName = "Kirilyc",
                LastName = "Lefi",
                Salary = 4400.00M,
                Manager = employee1,
                Birthday = DateTime.Parse("1981-03-12")
            };
            employees.Add(employee2);

            var employee3 = new Employee
            {
                FirstName = "Stephen",
                LastName = "Bjorn",
                Salary = 4300.00M,
                Manager = employee1,
                Birthday = DateTime.Parse("1995-01-01")
            };
            employees.Add(employee3);

            this.context.Employees.AddRange(employees);
            this.context.SaveChanges();
        }
    }
}
