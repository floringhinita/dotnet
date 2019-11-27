using System;

/**
 * Write a function to remove duplicate characters from String.
 */
namespace app1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;

            do
            {
                Console.WriteLine("Enter phrase or press Esc to exit:");
                str = Console.ReadLine();

                Console.WriteLine(RemoveDupplicates(str));

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string RemoveDupplicates(string str)
        {
            string output = "";

            foreach (char chr in str)
            {
                if (output.IndexOf(chr) == -1)
                {
                    output += chr;
                }
            }

            return output;
        }
    }
}
