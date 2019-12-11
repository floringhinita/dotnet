namespace prob1
{
    using prob1.Core;
    using System.Diagnostics;
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            var stopwatch = Stopwatch.StartNew();

            App.RunAsync();

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}
