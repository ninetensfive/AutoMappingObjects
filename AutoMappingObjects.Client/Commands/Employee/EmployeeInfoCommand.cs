using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Client.Commands.Employee
{
    public class EmployeeInfoCommand : ICommand
    {
        private IEmployeeService employeeService;

        public EmployeeInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var employeeId = int.Parse(arguments[0]);

            return employeeService.EmployeeInfo(employeeId);
        }
    }
}
