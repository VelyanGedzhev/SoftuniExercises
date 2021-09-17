using System;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputInfo = Console.ReadLine()
                .Split();

            ListyIterator<string> collection;

            if (inputInfo.Length > 1)
            {
                collection = new ListyIterator<string>(inputInfo.Skip(1));
            }
            else
            {
                collection = new ListyIterator<string>();
            }
            Console.WriteLine(CommandsExecution(collection));
        }
        private static string CommandsExecution(ListyIterator<string> collection)
        {
            var sb = new StringBuilder();
            var command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                try
                {
                    switch (command[0])
                    {
                        case "Move":
                            sb.AppendLine(collection.Move().ToString());
                            break;
                        case "Print":
                            sb.AppendLine(collection.Print());
                            break;
                        case "HasNext":
                            sb.AppendLine(collection.HasNext().ToString());
                            break;
                        case "PrintAll":
                            foreach (var item in collection)
                            {
                                sb.Append($"{item} ");
                            }

                            sb.Remove(sb.Length - 1, 1);
                            sb.AppendLine();
                            break;
                        
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    sb.AppendLine(ae.Message);
                }

                command = Console.ReadLine().Split();
            }

            return sb.ToString().Trim();
        }
    }
}
