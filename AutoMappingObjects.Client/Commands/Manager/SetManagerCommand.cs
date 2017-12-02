using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Client.Commands.Manager
{
    class SetManagerCommand : ICommand
    {
        private IEmployeeService employeeService;

        public SetManagerCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var employeeId = int.Parse(arguments[0]);
            var managerId = int.Parse(arguments[1]);

            var manager = employeeService.SetManager<ManagerDTO>(employeeId, managerId);
            var employee = employeeService.GetEmployeeById<EmployeeDTO>(employeeId);

            return $"Manager {manager.FirstName} {manager.LastName} was added to employee {employee.FirstName} {employee.LastName}.";
        }
    }
}
