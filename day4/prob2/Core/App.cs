using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace prob2.Core
{
    class App
    {
        private static readonly string Path = @"C:\Users\TTC056-0\source\repos\dotnet\day4\prob2\data\";

        private static readonly bool GenerateFiles = false;
        public static void Run()
        {
            if (GenerateFiles)
            {
                FileGenerator.Create(10, Path);
            }


            string[] files = Directory.GetFiles(Path, "*.dat");
            
            foreach (string file in files)
            {
                Task task1 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(file);
                    return "a";

                });

                Task task2 = task1.ContinueWith(ant => {
                    Console.WriteLine(ant);
                });

                task1.Wait();
            }

        }
    }
}
