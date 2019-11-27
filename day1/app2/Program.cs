using System;
using System.Collections.Generic;

/**
 * Given an unsorted array which has a number in the majority (a number appears more than 50% in the array/list), find that number.
 */
namespace app2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputArr  = new List<int>();
            List<int> found     = new List<int>();
            string str;
            int perc;

            do
            {
                Console.WriteLine("\nEnter numbers separated by space or press Esc to exit:");

                inputArr = ReadArray(" ");
                
                Console.WriteLine("Enter percentage: ");

                str = Console.ReadLine();
                
                Int32.TryParse(str, out perc);

                int searched = (int)(inputArr.Count * (perc * 0.01));

                found = FindByPercentage(CountFrequency(inputArr), searched);

                if (found.Count > 0)
                {
                    Console.WriteLine("The numbers matching {0}% frequency are:", perc);
                    foreach (int item in found)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("No number was found to match the {0}% frequency.", perc);
                }

                inputArr.Clear();
                found.Clear();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static List<int> ReadArray(string separator)
        {
            int copy;
            List<int> list = new List<int>();

            string str = Console.ReadLine();

            string[] inputArr = str.Split(separator);

            foreach (string s in inputArr)
            {
                if (Int32.TryParse(s, out copy))
                {
                    list.Add(copy);
                }
            }

            return list;
        }

        static Dictionary<int, int> CountFrequency(List<int> arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach(int el in arr)
            {
                if ( ! dict.ContainsKey(el))
                {
                    dict[el] = 0;
                }

                dict[el]++;
            }

            return dict;
        }

        static List<int> FindByPercentage(Dictionary<int, int> dict, int search)
        {
            List<int> list = new List<int>();
            
            foreach (var el in dict)
            {
                if (el.Value >= search)
                {
                    list.Add(el.Key);
                }
            }

            return list;
        }
    }
}
