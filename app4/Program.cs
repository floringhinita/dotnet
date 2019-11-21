using System;
using System.Collections.Generic;
/*
* Write code to reverse a linked list, if you able to do it using loops, try to solve with recursion.
*/
namespace app4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] o = { 1, 2, 3};
            ReversableLinkedList<object> list = new ReversableLinkedList<object>();
            foreach (int i in o)
            {
                list.AddLast(i);
            }

            list.Reverse2();
            Console.WriteLine("Recursively reverse: {0}", list);

            list.Reverse();
            Console.WriteLine(list);
        }
    }
}
