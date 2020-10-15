using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> members { get; set; }
        public Family()
        {
            members = new List<Person>();
        }
        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            //int maxAge = int.MinValue;
            //Person person = null;

            //foreach (var member in people)
            //{
            //    var currentAge = member.Age;
            //    if (currentAge > maxAge)
            //    {
            //        maxAge = currentAge;
            //        person = member;
            //    }
            //}
            //return person;

            //Person oldestPerson = people.OrderByDescending(x => x.Age).First();
            //return oldestPerson;

            return members.OrderByDescending(x => x.Age).First();
        }

        public Person[] GetPeople()
        {
            var people = members.Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToArray();

            return people;
        }
    }
}
