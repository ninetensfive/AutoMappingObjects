using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Client.Commands.Employee
{
    public class SetAddressCommand : ICommand
    {
        private IEmployeeService employeeService;

        public SetAddressCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var employeeId = int.Parse(arguments[0]);
            var employeeAddress = arguments[1];

            var employee = this.employeeService.SetAddress<EmployeeDTO>(employeeId, employeeAddress);

            return $"Employee {employee.FirstName} {employee.LastName} address was set to {employeeAddress}.";
        }
    }
}
