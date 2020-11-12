using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, CorpEnum corp) 
            : base(id, firstName, lastName, salary)
        {
            Corp = TryParseCorps(corp.ToString());
        }

        public CorpEnum Corp { get; }

        private CorpEnum TryParseCorps(string corpsStr)
        {

            bool parsed = Enum.TryParse<CorpEnum>(corpsStr, out CorpEnum corps);
            if (!parsed)
            {
                throw new ArgumentException("Invalid Corp!");
            }
            return corps;
        }

    }
}
