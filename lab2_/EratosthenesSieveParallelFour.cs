using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_
{
    /* Parallel algorithm 4 */
    class EratosthenesSieveParallelFour : EratosthenesSieve, IEratosthenesSieve
    {
        public double mWorkTime { get; private set; }

        private int mThreadsCount;
        private static int mCurrentPrime;
        private Thread[] mThreads;
        private static object Locker = new object();

        public EratosthenesSieveParallelFour(int N, int threadsCount) : base(N)
        {
            mCurrentPrime = 2;
            mThreadsCount = threadsCount;
        }
        
        static void Find()
        {
            while(true)
            {
                if (mCurrentPrime >= mSqrtN)
                    break;

                int prime;
                lock(Locker)
                {
                    prime = mCurrentPrime++;
                }

                for (int i = mSqrtN; i < mN; i++)
                {
                    if (i % prime == 0)
                        mPrimes[i] = 0;
                }
            }
        }

        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            /* timer start */
            sw.Start();

            /* define base prime numbers  */
            base.defineBasePrimes();

            mThreads = new Thread[mThreadsCount];
            /* start threads */
            for (int i = 0; i < mThreads.Length; i++)
            {
                mThreads[i] = new Thread(Find);
                mThreads[i].Start();
            }

            /* synchronization method that blocks the calling thread 
               (that is, the thread that calls the method) until the thread whose Join method is called has completed.  */
            foreach (Thread t in mThreads)
                t.Join();

            /* timer stop */
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            /*  get worktime */
            mWorkTime = ts.TotalMilliseconds;
        }
    }
}
