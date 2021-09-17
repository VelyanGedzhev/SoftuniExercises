using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, CorpEnum corp, ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corp)
        {
            Missions = missions;
        }

        public ICollection<IMission> Missions { get; }
    }
}
