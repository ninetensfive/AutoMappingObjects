using AutoMappingObjects.Client.Contracts;
using System;

namespace AutoMappingObjects.Client.Commands
{
    public class ExitCommand : ICommand
    {
        private IWriter writer;

        public ExitCommand(IWriter writer)
        {
            this.writer = writer;
        }

        public string Execute(params string[] arguments)
        {
            this.writer.WriteLine("Bye bye!");
            Environment.Exit(0);

            return String.Empty;
        }
    }
}
