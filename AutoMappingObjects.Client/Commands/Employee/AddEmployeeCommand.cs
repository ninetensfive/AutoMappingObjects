using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Services.Contracts;
using System;

namespace AutoMappingObjects.Client.Commands.Employee
{
    public class AddEmployeeCommand : ICommand
    {
        private IEmployeeService employeeService;

        public AddEmployeeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var firstName = arguments[0];
            var lastName = arguments[1];
            var salary = decimal.Parse(arguments[2]);

            this.employeeService.AddEmployee<EmployeeDTO>(firstName, lastName, salary);

            return $"Employee {firstName} {lastName} was added successfully.";
        }
    }
}
