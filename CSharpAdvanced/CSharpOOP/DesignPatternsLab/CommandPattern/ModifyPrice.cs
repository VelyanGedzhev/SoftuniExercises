using CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke()
        {
            this.commands.Add(this.command);
            this.command.ExecuteAction();
        }
    }
}
