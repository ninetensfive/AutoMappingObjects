using AutoMappingObjects.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoMappingObjects.Client.Core
{
    public class CommandDispacher
    {
        private IServiceProvider serviceProvider;

        public CommandDispacher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Dispach(string command, string[] parameters)
        {            
            var assembly = Assembly.GetExecutingAssembly();
            var commandType = assembly
                .GetTypes()
                .Where(
                t => t.GetInterfaces().Contains(typeof(ICommand)) &&
                t.Name == command + "Command"
                ).SingleOrDefault();

            if(commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var result = ExecuteCommand(commandType, parameters);

            return result;
        }

        private string ExecuteCommand(Type commandType, string[] parameters)
        {
            var constructorInfo = commandType.GetConstructors().First();
            var services = InjectServices(constructorInfo);

            var instance = (ICommand)constructorInfo.Invoke(services);
            var result = instance.Execute(parameters);

            return result;
        }

        private Object[] InjectServices(ConstructorInfo constructorInfo)
        {
            var constructorParameters = constructorInfo
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            var services = constructorParameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            return services;
        }
    }
}
