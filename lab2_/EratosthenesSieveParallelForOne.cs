using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_
{
    class EratosthenesSieveParallelForOne : IEratosthenesSieve
    {
        /* upper bound for prime numbers range */
        private static int mN;
        private static int mSqrtN;
        /* 1 - prime, 0 - not prime */
        /* m.b. use bool type */
        private static int[] mPrimes;

        public double mWorkTime { get; private set; }

        public EratosthenesSieveParallelForOne(int N)
        {
            mN = N;
            mSqrtN = Convert.ToInt32(Math.Ceiling(Math.Sqrt(mN)));
            mPrimes = new int[mN];
            /*  let's pretend that all numbers is prime */
            for (int i = 0; i < mPrimes.Length; i++) mPrimes[i] = 1;
        }

        static void Find(int prime)
        {
            for (int i = mSqrtN; i < mPrimes.Length; i++)
            {
                if (i % prime == 0)
                    mPrimes[i] = 0;
            }
        }

        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            /* timer start */
            sw.Start();

            /* define base prime numbers  */
            for (int i = 2; i < mSqrtN; i++)
            {
                if (mPrimes[i] != 0)
                    for (int j = 2 * i; j < mSqrtN; j += i) mPrimes[j] = 0;
            }

            Parallel.For(2, mSqrtN, Find);

            /* timer stop */
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            /*  get worktime */
            mWorkTime = ts.TotalMilliseconds;
        }
    }
}
