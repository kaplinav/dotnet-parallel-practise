using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_
{
    /* linear algorithm */
    class EratosthenesSieveLinear : EratosthenesSieve, IEratosthenesSieve
    {
        public double mWorkTime { get; private set; }

        public EratosthenesSieveLinear(int N) : base(N)
        {
        }

        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            base.defineBasePrimes();
            for (int i = 2; i < mSqrtN; i++)
            {
                /* if current number is prime */
                if (mPrimes[i] != 0)
                {
                    for (int j = mSqrtN; j < mPrimes.Length; j++)
                    {
                        if (j % i == 0) mPrimes[j] = 0;
                    }
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            mWorkTime = ts.TotalMilliseconds;
        }
    }
}