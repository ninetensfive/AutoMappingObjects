using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Data
{
    public static class Configuration
    {
        public const string ConnectionString = @"Server = .;" + 
                                                "Database = AutoMappingObjects; " +
                                                "Integrated Security = yes";
    }
}
