using System;

namespace ImplementingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 5; i++)
            {
                list.AddHead(new Node(i));
            }

            list.RemoveItem(2);

            list.PrintList();

            Console.WriteLine(list.ToArray().Length);

            //LinkedList list = new LinkedList();

            //for (int i = 0; i < 5; i++)
            //{
            //    list.AddHead(new Node(i));
            //}
            //list.PrintList();
            //Console.WriteLine();
            //list.ReverseList();
        }
    }
}
