using AutoMappingObjects.Client.Contracts;
using System;

namespace AutoMappingObjects.Client.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
