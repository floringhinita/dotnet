using System;

namespace prob3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exceptions.InvalidRangeException<int>(30, 1, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                DateTime dt = new DateTime();

                throw new Exceptions.InvalidRangeException<DateTime>(dt, dt.AddDays(3), dt.AddDays(4));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
