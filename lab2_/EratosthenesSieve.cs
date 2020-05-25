using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_
{
    class EratosthenesSieve
    {
        protected static int mN;
        protected static int mSqrtN;
        protected static int[] mPrimes;

        public EratosthenesSieve(int N)
        {
            mN = N;
            mSqrtN = Convert.ToInt32(Math.Ceiling(Math.Sqrt(mN)));
            mPrimes = new int[mN];
            /*  let's pretend that all numbers is prime */
            for (int i = 0; i < mPrimes.Length; i++) mPrimes[i] = 1;
        }

        protected void defineBasePrimes()
        {
            /* define base prime numbers  */
            for (int i = 2; i < mSqrtN; i++)
            {
                if (mPrimes[i] != 0)
                    for (int j = 2 * i; j < mSqrtN; j += i) mPrimes[j] = 0;
            }
        }
    }
}
