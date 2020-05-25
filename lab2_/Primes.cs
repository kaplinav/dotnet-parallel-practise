using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_
{
    class Primes
    {
        /* 1 - prime, 0 - not prime */
        /* m.b. use bool type */
        public int[] mPrimes { get; set; }
        /* upper bound for prime numbers range */
        public int mN { get; private set; }
        public int mSqrtN { get; private set; }

        public Primes(int N)
        {
            mN = N;
            init();
        }

        private void init()
        {
            mSqrtN = Convert.ToInt32(Math.Ceiling(Math.Sqrt(mN)));
            mPrimes = new int[mN];
            /*  let's pretend that all numbers is prime */
            for (int i = 0; i < mPrimes.Length; i++) mPrimes[i] = 1;
        }
    }
}
