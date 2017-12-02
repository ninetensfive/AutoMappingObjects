using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Client.Commands.Employee
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private IEmployeeService employeeService;

        public ListEmployeesOlderThanCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var age = int.Parse(arguments[0]);
            var employees = this.employeeService.ListEmployeesOlderThan<EmployeeDTO>(age);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var managerName = "[no manager]";

                if(employee.Manager != null)
                {
                    managerName = employee.Manager.LastName;
                }

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:F2} - Manager: {managerName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
