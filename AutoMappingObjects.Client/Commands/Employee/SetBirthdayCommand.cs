using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Services.Contracts;
using System;
using System.Globalization;

namespace AutoMappingObjects.Client.Commands.Employee
{
    public class SetBirthdayCommand : ICommand
    {
        private IEmployeeService employeeService;

        public SetBirthdayCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            var employeeId = int.Parse(arguments[0]);
            var employeeBirthday = DateTime.ParseExact(arguments[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var employee = employeeService.SetBirthday<EmployeeDTO>(employeeId, employeeBirthday);

            return $"Employee {employee.FirstName} {employee.LastName} birthday was set to {arguments[1]}";
        }
    }
}
