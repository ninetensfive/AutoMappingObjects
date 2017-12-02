using System;
using AutoMappingObjects.Data;
using AutoMappingObjects.Services.Contracts;

namespace AutoMappingObjects.Services
{
    public class EmployeeService : IEmployeeService
    {
        private AutoMappingObjectsContext context;

        public EmployeeService(AutoMappingObjectsContext context)
        {

        }

        public TModel AddEmployee<TModel>(string firstName, string lastName, decimal salary)
        {
            throw new NotImplementedException();
        }

        public string EmployeeInfo(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void SetAddress(int employeeId, string address)
        {
            throw new NotImplementedException();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
