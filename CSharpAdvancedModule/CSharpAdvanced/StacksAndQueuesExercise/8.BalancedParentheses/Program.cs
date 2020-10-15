using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length / 2)
                {
                    stack.Push(input[i]);
                }
                else
                {
                    queue.Enqueue(input[i]);
                }
            }
            bool isBalanced = true;

            while (stack.Count > 0)
            {
                char first = stack.Pop();
                char second = queue.Dequeue();

                if (!((first == '[' && second == ']') ||
                    (first == '(' && second == ')') ||
                    (first == '{' && second == '}')))
                {
                    
                    isBalanced = false;
                    break;
                }
            }
            if (isBalanced && queue.Count < 1)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            
        }
    }
}
