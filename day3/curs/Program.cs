using System;
using System.Collections.Generic;
using System.Linq;

namespace curs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var querySmallNums =
                from num in numbers
                where num < 5
                select num;

            foreach (var num in querySmallNums)
            {
                Console.Write(num.ToString() + " ");
            }
            Console.WriteLine();

            var q2 = numbers.Where(n => n < 5);

            foreach (var num in q2)
            {
                Console.Write(num.ToString() + " ");
            }
            return;
            string s = "aaa";

            Console.WriteLine(s.Append("ppp").Append("xxx").Append("ooo"));

            List<int> l = new List<int>() { 1, 2, 3, 4};

            l.Increase(10);

            l.Where(o => o > 3);

            foreach(int i in l)
            {
                Console.WriteLine(i);
            }
        }

    }

    public static class Extension
    {
        public static string Append(this string str, string wtf)
        {
            return str + " " + wtf;
        }

        public static IList<int> Increase(this IList<int> list, int amount)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += amount;
            }

            return list;
        }
    }
}
