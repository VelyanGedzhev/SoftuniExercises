using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputInfo = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            while (inputInfo[0] != "END")
            {
                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);
                string town = inputInfo[2];

                Person person = new Person(name,age,town);
                people.Add(person);

                inputInfo = Console.ReadLine()
                .Split();
            }
            int n = int.Parse(Console.ReadLine());

            Person comparedPerson = people[n - 1];
            int samePersonCount = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(comparedPerson) == 0)
                {
                    samePersonCount++;
                }
            }

            if (samePersonCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notSamePersonCount = people.Count - samePersonCount;
                Console.WriteLine($"{samePersonCount} {notSamePersonCount} {people.Count}");
            }
        }
    }
}
