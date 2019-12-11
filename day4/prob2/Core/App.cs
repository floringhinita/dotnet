using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

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

            List<Task<string>> allTasks = new List<Task<string>>();

            Parallel.ForEach(files, (file) =>
            {
                Task<string> task = Task<string>.Run(() => 
                {
                    Console.WriteLine($"{Task.CurrentId} {file}");

                    return ReadFile(file);
                });

                Task task2 = task.ContinueWith((prev) =>
                {
                    Console.WriteLine($"{Task.CurrentId} processing content");

                    int xx = CountWords(prev.Result);
                    // int xx2 = CountDistinctWords(prev.Result);

                    Console.WriteLine($"Word count {xx}");
                    // Console.WriteLine($"Distinct word count {xx2}");
                });

                task2.Wait();
            });

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
