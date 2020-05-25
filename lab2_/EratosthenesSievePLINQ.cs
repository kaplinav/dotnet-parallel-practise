using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_
{
    /* Find prime numbers with PLINQ */
    class EratosthenesSievePLINQ : IEratosthenesSieve
    {
        /* upper bound for numbers range */
        private static int mN;
        /* numbers */
        private static int[] mNumbers;
        /* prime numbers */
        private static int[] mPrimes;

        public double mWorkTime { get; private set; }

        public EratosthenesSievePLINQ(int N)
        {
            mN = N;
            mNumbers = new int[mN];
            for (int i = 0; i < mNumbers.Length; i++) mNumbers[i] = i + 1;
        }

        public void Start()
        {
            /* define IsPrime delegate */
            Func<int, bool> IsPrime = number =>
            {
                if (number < 2) return false;

                for (int i = 2; i * i <= number; i++)
                {
                    if (i != number)
                        if (number % i == 0) return false;
                }

                return true;
            };

            Stopwatch sw = new Stopwatch();
            /* timer start */
            sw.Start();

            /* use PLINQ to find the prime numbers */
            var plinq =
                from int number in mNumbers.AsParallel()
                where IsPrime(number)
                select number;
            mPrimes = plinq.ToArray();

            /* timer stop */
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            /*  get worktime */
            mWorkTime = ts.TotalMilliseconds;
        }
    }
}
