using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7._OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<People> people = new List<People>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input
                    .Split()
                    .ToArray();

                People person = new People(data);
                people.Add(person);
            }

            Console.WriteLine(String.Join(Environment.NewLine, people.OrderBy(x =>x.PersonAge)));
        }
        public class People
        {
            public string PersonName { get; set; }
            public string PersonID { get; set; }
            public int PersonAge { get; set; }

            public People(string[] data)
            {
                PersonName = data[0];
                PersonID = data[1];
                PersonAge = int.Parse(data[2]);
            }
            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                result.Append(PersonName + " ");
                result.Append("with ID: " + PersonID + " ");
                result.Append("is " + PersonAge + " years old.");

                return result.ToString().TrimEnd(); 
            }
        }
    }
}
