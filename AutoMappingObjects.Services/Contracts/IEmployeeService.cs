using System;

namespace AutoMappingObjects.Services.Contracts
{
    public interface IEmployeeService
    {
        TModel AddEmployee<TModel>(string firstName, string lastName, decimal salary);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        string EmployeeInfo(int employeeId);
    }
}
