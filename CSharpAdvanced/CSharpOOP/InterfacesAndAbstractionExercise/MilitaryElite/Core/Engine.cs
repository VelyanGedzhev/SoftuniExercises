using MilitaryElite.Core.Interfaces;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                int id = int.Parse(commandArgs[1]);
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                ISoldier soldier;
                ICollection<ISoldier> soldiers = new List<ISoldier>();
                ICollection<ISoldier> privates = new List<IPrivate>();

                if (type == "Private")
                {
                    soldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(soldier);
                }
                else if (type == "LeutenantGeneral")
                { 
                    string[] soldiersToAdd = commandArgs.Skip(5).ToArray();

                    foreach (var item in soldiersToAdd)
                    {
                        int soldierId = int.Parse(item);

                        privates.Add(soldiers.FirstOrDefault(i => i.Id == soldierId));
                    }
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (type == "Engineer")
                {
                    string corp = commandArgs[5];
                }
            }
        }
    }
}
