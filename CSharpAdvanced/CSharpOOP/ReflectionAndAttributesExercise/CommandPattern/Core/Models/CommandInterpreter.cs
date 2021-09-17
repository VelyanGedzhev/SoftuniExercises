using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputTokens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = inputTokens[0].ToLower();
            string[] commandArgs = inputTokens
                .Skip(1)
                .ToArray();

            string result = string.Empty;


            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == $"{commandType}Command".ToLower());

            ICommand commandInstance = (ICommand)Activator
                .CreateInstance(type);


            //Solution without reflection
            // ICommand command = null;
            //if (commandType == "HelloCommand")
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandType == "ExitCommand")
            //{
            //    command = new ExitCommand();
            //}


            result = commandInstance.Execute(commandArgs);
            return result;
        }
    }
}
