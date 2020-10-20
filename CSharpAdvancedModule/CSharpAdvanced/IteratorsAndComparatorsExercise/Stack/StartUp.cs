using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            var inputInfo = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (inputInfo[0] != "END")
            {
                switch (inputInfo[0])
                {
                    case "Push":
                        var elements = inputInfo.Skip(1).Select(int.Parse);
                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }

                        break;
                    default:
                        break;
                }

                inputInfo = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            PrintStack(stack);
            PrintStack(stack);
        }
        private static void PrintStack(Stack<int> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
