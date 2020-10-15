using System;
using System.Collections.Generic;
using System.IO;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> merged = new HashSet<string>();
            using (StreamReader input1 = new StreamReader("../../../FileOne.txt"))
            {
                using (StreamReader input2 = new StreamReader("../../../FileTwo.txt"))
                {
                    var line = input1.ReadLine();
                    var line2 = input2.ReadLine();
                    while (line != null)
                    {
                        merged.Add(line);
                        merged.Add(line2);
                        line = input1.ReadLine();
                        line2 = input2.ReadLine();
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var item in merged)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
