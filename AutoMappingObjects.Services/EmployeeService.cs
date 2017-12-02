using System;
using AutoMappingObjects.Data;
using AutoMappingObjects.Services.Contracts;
using AutoMappingObjects.Models;
using AutoMapper;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static AutoMappingObjects.Services.Utilities.DateTimeUtilities;

namespace AutoMappingObjects.Services
{
    public class EmployeeService : IEmployeeService
    {
        private AutoMappingObjectsContext context;

        public EmployeeService(AutoMappingObjectsContext context)
        {
            this.context = context;
        }

        public TModel AddEmployee<TModel>(string firstName, string lastName, decimal salary)
        {
            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            return Mapper.Map<TModel>(employee); 
        }

        public string EmployeeInfo(int employeeId)
        {
            var employee = this.GetEmployeeById(employeeId);

            return $"{employee.Id} - {employee.FirstName} {employee.LastName} - {employee.Salary:F2}";
        }

        public TModel SetAddress<TModel>(int employeeId, string address)
        {
            var employee = this.GetEmployeeById(employeeId);
            employee.Address = address;

            this.context.SaveChanges();

            return Mapper.Map<TModel>(employee);
        }

        public TModel SetBirthday<TModel>(int employeeId, DateTime date)
        {
            var employee = this.GetEmployeeById(employeeId);
            employee.Birthday = date;

            this.context.SaveChanges();

            return Mapper.Map<TModel>(employee);
        }

        public TModel SetManager<TModel>(int employeeId, int managerId)
        {
            var employee = this.GetEmployeeById(employeeId);
            var manager = this.GetEmployeeById(managerId);

            employee.Manager = manager;

            this.context.SaveChanges();

            return Mapper.Map<TModel>(manager);
        }

        public IEnumerable<TModel> ListEmployeesOlderThan<TModel>(int age)
        {
            var employees = this.context
                .Employees
                .Where(e => e.Birthday != null && CalculateAge(e.Birthday) > age)
                .Include(e => e.Manager) 
                .ToList();

            return Mapper.Map<IEnumerable<TModel>>(employees);
        }

        public TModel GetEmployeeById<TModel>(int id)
        {
            var employee = this.GetEmployeeById(id);

            return Mapper.Map<TModel>(employee);
        }

        private Employee GetEmployeeById(int id)
        {
            var employee = this.context
                .Employees
                .Include(e => e.Subordinates)
                .SingleOrDefault(e => e.Id == id);
                

            if(employee == null)
            {
                throw new ArgumentException("No such employee!");
            }

            return employee;
        }
    }
}
