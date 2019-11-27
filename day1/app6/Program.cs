using System;

namespace app6
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

                Console.WriteLine(GetLastWord(str).Length);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string GetLastWord(string s)
        {
            string[] p = s.Trim().Split(" ");

            return p.Length > 0 ? p[p.Length - 1] : "";
        }
    }
}
