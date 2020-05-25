using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_
{
    /* Parallel algorithm 1 */
    class EratosthenesSieveParallelOne : EratosthenesSieve, IEratosthenesSieve
    {
        private Thread[] mThreads;
        private int mThreadsCount;

        public double mWorkTime { get; private set; }

        public EratosthenesSieveParallelOne(int N, int threadsCount) : base(N)
        {
            mThreadsCount = threadsCount;
        }

        static void Find(Object range)
        {
            Range r = (Range)range;

            for (int i = 2; i < mSqrtN; i++)
            {
                /* if current number is prime */
                if (mPrimes[i] != 0)
                {
                    for (int j = r.mBegin; j < r.mEnd; j++)
                    {
                        if (j % i == 0)
                            mPrimes[j] = 0;
                    }
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
            int numbersPerThread = Convert.ToInt32(Math.Ceiling((mN - mSqrtN) / Convert.ToDouble(mThreadsCount)));

            /* start threads */
            for (int i = 0; i < mThreadsCount; i++)
            {
                /* define range for current thread */
                int begin = mSqrtN + i * numbersPerThread;
                int end = begin + numbersPerThread;

                if (end > mN)
                    end = mN;

                mThreads[i] = new Thread(Find);
                mThreads[i].Start(new Range(begin, end));
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