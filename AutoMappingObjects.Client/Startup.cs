using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.Core;
using AutoMappingObjects.Client.IO;
using AutoMappingObjects.Data;
using AutoMappingObjects.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using AutoMapper;
using AutoMappingObjects.Services.Contracts;

namespace AutoMappingObjects.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {            
            IServiceProvider serviceProvider = GetServiceProvider();

            IReader reader = new Reader();
            IWriter writer = new Writer();

            var dispacher = new CommandDispacher(serviceProvider);
            var engine = new Engine(dispacher, reader, writer);

            engine.Run();
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<AutoMappingObjectsContext>();
            serviceCollection.AddAutoMapper();

            serviceCollection.AddTransient<IWriter, Writer>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
