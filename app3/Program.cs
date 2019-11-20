using System;
using System.Collections.Generic;

/*
 * Count the frequency of chars in a string.
 */
namespace app3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            do
            {
                Console.WriteLine("Enter phrase or press Esc to exit:");

                str = Console.ReadLine();

                dict = CountFrequency(str);
                foreach (var item in dict)
                {
                    Console.WriteLine("{0} appears {1} times.", item.Key, item.Value);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static Dictionary<char, int> CountFrequency(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if ( ! dict.ContainsKey(c))
                {
                    dict[c] = 0;
                }

                dict[c]++;
            }

            return dict;
        }
    }
}
