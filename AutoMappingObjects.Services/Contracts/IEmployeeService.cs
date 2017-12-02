using System;
using System.Collections.Generic;

namespace AutoMappingObjects.Services.Contracts
{
    public interface IEmployeeService
    {
        TModel AddEmployee<TModel>(string firstName, string lastName, decimal salary);

        TModel SetBirthday<TModel>(int employeeId, DateTime date);

        Tmodel SetAddress<Tmodel>(int employeeId, string address);

        string EmployeeInfo(int employeeId);

        TModel SetManager<TModel>(int employeeId, int managerId);

        TModel GetEmployeeById<TModel>(int id);

        IEnumerable<TModel> ListEmployeesOlderThan<TModel>(int age);
    }
}
