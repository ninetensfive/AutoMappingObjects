using AutoMappingObjects.Client.Contracts;
using AutoMappingObjects.Client.Utilities;
using System;
using System.Linq;

namespace AutoMappingObjects.Client.Core
{
    public class Engine
    {
        private CommandDispacher dispacher;
        private IReader reader;
        private IWriter writer;

        public Engine(CommandDispacher dispacher, IReader reader, IWriter writer)
        {
            this.dispacher = dispacher;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {            
            while(true)
            {
                try
                {
                    var input = reader.ReadLine().SplitInput();
                    var command = input[0];
                    var parameters = input.Skip(1).ToArray();

                    var result = dispacher.Dispach(command, parameters);

                    this.writer.WriteLine(result);

                }catch(Exception e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}
