using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] tasksData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksData);
            Queue<int> threads = new Queue<int>(threadsData);

            while (true)
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();
                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
                    if (threads.Count > 0)
                    {
                        Console.WriteLine(string.Join(" ", threads));
                        break;
                    }
                }
                if (currentThread >= currentTask)
                {
                   
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if(currentThread < currentTask)
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
