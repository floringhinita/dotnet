using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] p = {'a', 'b', 'c'};

            Console.WriteLine($"MIN: {p.Min()}");
            Console.WriteLine($"MAX: {p.Max()}");
            Console.WriteLine($"SUM: {p.Sum()}");
            Console.WriteLine($"PRODUCT: {p.Product()}");
            Console.WriteLine($"AVERAGE: {p.Average()}");

            int[] l = { 1, 2, 3, 4 };

            Console.WriteLine($"MIN: {l.Min()}");
            Console.WriteLine($"MAX: {l.Max()}");
            Console.WriteLine($"SUM: {l.Sum()}");
            Console.WriteLine($"PRODUCT: {l.Product()}");
            Console.WriteLine($"AVERAGE: {l.Average()}");


        }
    }

    public static class Extensions
    {
        public static T Min<T>(this IEnumerable<T> source) where T : struct
        {
            T aux = default(T);

            foreach (T item in source)
	        {
                if (aux.Equals(default(T)) || (dynamic) item < aux)
                {
                    aux = item;
                }
	        }

            return aux;
        }

        public static T Max<T>(this IEnumerable<T> source) where T : struct
        {
            T aux = default(T);

            foreach (T item in source)
	        {
                if (aux.Equals(default(T)) || (dynamic) item > aux)
                {
                    aux = item;
                }
	        }

            return aux;
        }

        public static T Sum<T>(this IEnumerable<T> source) where T : struct
        {
            T aux = default(T);

            foreach (T item in source)
	        {
                aux += (dynamic) item;
	        }

            return aux;
        }

        public static T Product<T>(this IEnumerable<T> source) where T : struct
        {
            T aux = default(T);

            foreach (var item in source)
            {
                aux *= (dynamic)item;
            }

            return aux;
        }

        public static double Average<T>(this IEnumerable<T> source) where T : struct
        {
            return (dynamic) source.Sum() / source.Count();
        }

    }
}
