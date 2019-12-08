namespace prob1.Core
{
    using System;

    public static class Extensions
    {
        public static int CountDivisors(this int num)
        {
            int divisors = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    divisors++;
                }
            }

            return divisors;
        }
    }
}