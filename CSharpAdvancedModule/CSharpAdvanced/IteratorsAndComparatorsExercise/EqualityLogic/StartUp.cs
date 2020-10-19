using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Person> peopleHasSet = new HashSet<Person>();
            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);

                Person person = new Person(name, age);
                peopleHasSet.Add(person);
                peopleSortedSet.Add(person);
            }
            Console.WriteLine(peopleHasSet.Count);
            Console.WriteLine(peopleSortedSet.Count);
        }
    }
}
