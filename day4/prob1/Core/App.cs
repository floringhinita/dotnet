using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace prob1.Core
{
    class App
    {
        private static Dictionary<int, int> _dict = new Dictionary<int, int>();
        private static int N = 100000;

        public static void RunAsync()
        {
            int proc = Environment.ProcessorCount;

            int batches = (N / proc);
            List<Thread> threads = new List<Thread>();

            for(int i = 0; i < proc; i++)
            {
                int[] list = BuildAnArray(i * batches, batches);

                Thread th = new Thread(Calculate);
                th.Start(list);

                threads.Add(th);
            }

            foreach(Thread thh in threads)
            {
                thh.Join();
            }

            var p = _dict.OrderByDescending(o => o.Value).FirstOrDefault();

            Console.WriteLine($"{p.Key} -- {p.Value}"); 
        }

        public static void Run()
        {
            int[] list = BuildAnArray(1, N);

            int max = 0;
            int nr = 0;

            foreach (int i in list)
            {
                int divisors = i.CountDivisors();
                if (divisors > max)
                {
                    max = divisors;
                    nr = i;
                }
            }

            Console.WriteLine($"{nr} -- {max}");
        }

        public static void Calculate(object obj)
        {
            int[] _list = obj as int[];

            foreach (int o in _list)
            {
                int divisors = o.CountDivisors();

                lock (_dict)
                {
                    _dict.Add(o, divisors);
                }
            }

            // _sem.Release();
        }

        public static int[] BuildAnArray(int from, int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = from + i;
            }

            return array;
        }
    }
}
