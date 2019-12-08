namespace prob1
{
    using prob1.Core;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {

            var stopwatch = Stopwatch.StartNew();

            App.Run();
            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}
