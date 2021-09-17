using System;
using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    var line = reader.ReadLine();
                    int index = 0;
                    while (line != null)
                    {
                        writer.WriteLine($"{index}. {line}");
                        Console.WriteLine($"{index}. {line}");
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
