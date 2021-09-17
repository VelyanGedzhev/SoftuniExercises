using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("gosho");
            list.Add("pesho");
            list.Add("vancho");
            list.Add("petko");
            list.Add("mitko");

            Console.WriteLine(list.RandomString());
        }
    }
}
