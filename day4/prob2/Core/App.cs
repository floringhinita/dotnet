using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace prob2.Core
{
    class App
    {
        private static string Path = @"C:\Users\TTC056-0\source\repos\dotnet\day4\prob2\data\";

        private static readonly bool GenerateFiles = false;
        public static void Run()
        {
            // Path = Directory.GetCurrentDirectory();

            if (GenerateFiles)
            {
                FileGenerator.Create(5, Path);
            }

            string[] files = Directory.GetFiles(Path, "*.dat");

            ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(files, (file) =>
            {
                Task<string> task = Task<string>.Run(() =>
                {
                    return ReadFile(file);
                });

                var xxxx = task.Result;
                string[] words = xxxx.Split(' ');

                Parallel.Invoke(
                    () => {

                        int currentLength = 0;

                        dict.TryGetValue("words", out currentLength);

                        Console.WriteLine($"current length = {currentLength}");
                        Console.WriteLine($"words count = {words.Count()}");

                        dict.TryAdd("words", words.Count() + currentLength);
                    },
                    () => {
                        int currentLength = 0;

                        dict.TryGetValue("xs", out currentLength);

                        var xs = from w in words
                                 where w.Length < 2
                                 select w;

                        Console.WriteLine($"current length = {currentLength}");
                        Console.WriteLine($"words count = {xs.Count()}");

                        dict.TryAdd("xs", currentLength + xs.Count());
                    });
            });

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }

        public static string ReadFile(string file)
        {
            StringBuilder x = new StringBuilder();
            foreach (string line in File.ReadLines(file, Encoding.UTF8))
            {
                x.Append(line);
                x.Append(" ");
            }

            return x.ToString();
        }

        public static int CountWords(string str)
        {
            return str.Split(' ').Length;
        }

        public static int CountDistinctWords(string str)
        {
            return str.Split(' ').GroupBy(w => w).Count();
        }


    }
}
