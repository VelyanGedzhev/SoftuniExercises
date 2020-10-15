using System;

namespace ImplementingStackАndQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack myStack = new CustomStack();

            for (int i = 1; i <= 5; i++)
            {
                myStack.Push(i);
            }

            myStack.ForEach(e =>
            {
                Console.WriteLine(e);
            });
           
            
        }
    }
}
