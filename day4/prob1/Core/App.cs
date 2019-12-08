using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace prob1.Core
{
    class App
    {
        private static Dictionary<int, int> _dict = new Dictionary<int, int>();

        public static void Run()
        {
            int proc = Environment.ProcessorCount;

            int N = 1000;
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
