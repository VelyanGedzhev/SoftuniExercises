using System;

namespace _1.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> printer = a => Console.WriteLine(string.Join(Environment.NewLine, names));
            printer(names);
        }
    }
}
