using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_
{
    /* Parallel algorithm 3 */
    class EratosthenesSieveParallelThree : EratosthenesSieve, IEratosthenesSieve
    {
        public double mWorkTime { get; private set; }

        public EratosthenesSieveParallelThree(int N) : base(N)
        {
        }

        static void Find(Object array)
        {
            int prime = (int)((object[])array)[0];
            ManualResetEvent ev = (ManualResetEvent)((object[])array)[1];

            for (int i = mSqrtN; i < mN; i++)
            {
                if (i % prime == 0)
                    mPrimes[i] = 0;
            }

            ev.Set();
        }

        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            /* timer start */
            sw.Start();

            /* define base prime numbers  */
            base.defineBasePrimes();

            /* define list of signal events */
            var events = new List<ManualResetEvent>();

            /* add to pool work elements with parameters */
            for (int i = 2; i < mSqrtN; i++)
            {
                var newEvent = new ManualResetEvent(false);
                events.Add(newEvent);
                ThreadPool.QueueUserWorkItem(Find, new object[] { i, newEvent }); //{ i, events[i - 2] });
            }

            /* wait completing */
            var wait = true;
            while (wait)
            {
                WaitHandle.WaitAll(events.Take(60).ToArray());
                events.RemoveRange(0, events.Count > 59 ? 60 : events.Count);
                wait = events.Any();
            }

            /* timer stop */
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            /*  get worktime */
            mWorkTime = ts.TotalMilliseconds;
        }
    }
}
