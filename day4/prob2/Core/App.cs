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
                        int _currentLength;
                        dict.TryGetValue("words", out _currentLength);

                        Console.WriteLine($"{Task.CurrentId} words count = {words.Count()}, current length = {_currentLength}");

                        dict.AddOrUpdate("words", words.Count(), (k, v) => v + words.Count());
                    },
                    () => {

                        var wrds = from w in words.AsParallel()
                                 where w.Length <= 5
                                 select w;

                        int _currentLength;
                        dict.TryGetValue("xs", out _currentLength);

                        Console.WriteLine($"{Task.CurrentId} words count = {wrds.Count()}, current length = {_currentLength}");

                        dict.AddOrUpdate("xs", wrds.Count(), (k, v) => v + wrds.Count());
                    },
                    () => {

                        var wrds = from w in words.AsParallel()
                                   where w.Length >= 5 && w.Length <= 10
                                   select w;

                        int _currentLength;
                        dict.TryGetValue("s", out _currentLength);

                        Console.WriteLine($"{Task.CurrentId} words count = {wrds.Count()}, current length = {_currentLength}");

                        dict.AddOrUpdate("s", wrds.Count(), (k, v) => v + wrds.Count());
                    },
                    () => {

                        var wrds = from w in words.AsParallel()
                                where w.Length >= 10 && w.Length <= 15 
                                select w;

                        int _currentLength;
                        dict.TryGetValue("m", out _currentLength);

                        Console.WriteLine($"{Task.CurrentId} words count = {wrds.Count()}, current length = {_currentLength}");

                        dict.AddOrUpdate("m", wrds.Count(), (k, v) => v + wrds.Count());
                    },
                    () => {

                        var wrds = from w in words.AsParallel()
                                where w.Length >= 15 
                                select w;

                        int _currentLength;
                        dict.TryGetValue("l", out _currentLength);

                        Console.WriteLine($"{Task.CurrentId} words count = {wrds.Count()}, current length = {_currentLength}");

                        dict.AddOrUpdate("l", wrds.Count(), (k, v) => v + wrds.Count());
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
