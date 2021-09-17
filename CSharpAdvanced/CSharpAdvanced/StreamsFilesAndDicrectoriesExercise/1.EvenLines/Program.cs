using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {


                    string line = reader.ReadLine();
                    int counter = 1;

                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            Regex pattern = new Regex("[-,.!?]");
                            line = pattern.Replace(line, "@");
                            var currentLine = line.Split().ToArray().Reverse();
                            writer.WriteLine(string.Join(" ", currentLine));
                        }
                        counter++;
                        line = reader.ReadLine();

                    }
                }
            }
        }
    }
}
