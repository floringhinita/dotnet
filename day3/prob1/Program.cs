using System;

namespace prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> callbacks = new Action<string>(delegate (string message) 
            {
                // nada de nada
            });

            callbacks += WriteLine;
            callbacks += WriteFile;

            Timer t = new Timer(callbacks);
            t.Interval = 3;
            t.Start();
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine($"Line: {message}");
        }

        public static void WriteFile(string message)
        {
            Console.WriteLine($"File: {message}");
        }

    }
}
