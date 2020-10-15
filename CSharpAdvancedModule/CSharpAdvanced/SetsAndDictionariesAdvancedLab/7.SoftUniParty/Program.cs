using System;
using System.Collections.Generic;

namespace _7.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipList = new HashSet<string>();
            HashSet<string> regularList = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "PARTY")
            {
                bool isVip = false;
                string firstSymbol = command[0].ToString();
                int num = 0;

                if (int.TryParse(firstSymbol, out num))
                {
                    isVip = true;
                }
                if (isVip)
                {
                    vipList.Add(command);
                }
                else
                {
                    regularList.Add(command);
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "END")
            {
                bool isVip = false;

                string firstSymbol = command[0].ToString();
                int num = 0;

                if (int.TryParse(firstSymbol, out num))
                {
                    isVip = true;
                }
                if (isVip)
                {
                    vipList.Remove(command);
                }
                else
                {
                    regularList.Remove(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(vipList.Count + regularList.Count);
            foreach (var item in vipList)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regularList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
