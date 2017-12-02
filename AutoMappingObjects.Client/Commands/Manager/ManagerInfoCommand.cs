using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Client.Commands.Manager
{
    public class ManagerInfoCommand : ICommand
    {
        private IEmployeeService employeeService;

        public ManagerInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var managerId = int.Parse(arguments[0]);
            var manager = this.employeeService.GetEmployeeById<ManagerDTO>(managerId);

            var sb = new StringBuilder();
            sb.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.Subordinates.Count}");

            foreach (var subordinat in manager.Subordinates)
            {
                sb.AppendLine($"    -{subordinat.FirstName} {subordinat.LastName} - ${subordinat.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
