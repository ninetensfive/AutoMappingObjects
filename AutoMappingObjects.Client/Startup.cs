using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.Core;
using AutoMappingObjects.Client.IO;
using AutoMappingObjects.Data;
using AutoMappingObjects.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using AutoMapper;
using AutoMappingObjects.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AutoMappingObjects.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {            
            IServiceProvider serviceProvider = GetServiceProvider();

            //serviceProvider
            //    .GetService<IDatabaseInitializationService>()
            //    .Reset(true);

            IReader reader = new Reader();
            IWriter writer = new Writer();

            var dispacher = new CommandDispacher(serviceProvider);
            var engine = new Engine(dispacher, reader, writer);

            engine.Run();
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
            var config = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddDbContext<AutoMappingObjectsContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
               
            serviceCollection.AddAutoMapper();

            serviceCollection.AddTransient<IWriter, Writer>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
            serviceCollection.AddTransient<IDatabaseInitializationService, DatabaseInitializationService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
