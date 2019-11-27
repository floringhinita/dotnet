using System;
using System.Collections.Generic;

/*
 * Write code to remove duplicates from an unsorted linked list.
 */
namespace app5
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;

            do
            {
                Console.WriteLine("Enter list of elements or press Esc to exit:");
                str = Console.ReadLine();
                string[] p = str.Split(" ");

                List<string> cleanedList = RemoveDupplicates(p);

                Console.WriteLine("Cleaned list:");
                foreach(var item in cleanedList)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public static List<string> RemoveDupplicates(string[] list)
        {
            List<string> copy = new List<string>();

            foreach (var item in list)
            {
                if ( ! copy.Contains(item))
                {
                    copy.Add(item);
                }
            }

            return copy;
        }
    }
}
