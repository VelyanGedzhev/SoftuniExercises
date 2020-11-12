using MilitaryElite.Core.Interfaces;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine())!= "End")
            {
                string[] commandArgs = command
                    .Split();
                string type = commandArgs[0];

                ISoldier soldier;
                ICollection<ISoldier> soldiers = new List<ISoldier>();

                if (type == "Private")
                {
                    int id = int.Parse(commandArgs[1]);
                    string firstName = commandArgs[2];
                    string lastName = commandArgs[3];
                    decimal salary = decimal.Parse(commandArgs[4]);

                    soldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(soldier);
                }
                else if (type == "LeutenantGeneral")
                {
                    int id = int.Parse(commandArgs[1]);
                    string firstName = commandArgs[2];
                    string lastName = commandArgs[3];
                    decimal salary = decimal.Parse(commandArgs[4]);
                }
            }
        }
    }
}
