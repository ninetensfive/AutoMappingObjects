using AutoMappingObjects.Client.Contracts;
using System;

namespace AutoMappingObjects.Client.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
