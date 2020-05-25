using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2
{
    /* Parallel algorithm 1 */
    class EratosthenesSieveP1 : IEratosthenesSieve
    {
        public int N { get; private set; }
        public double Time { get; private set; }
        /* threads count */
        private int ThreadsCount = 2;
        /* 0 is Prime, 1 is not Prime */
        private int[] NotPrime;

        public EratosthenesSieveP1(int n)
        {
            this.N = n + 1;
            NotPrime = new int[N];
        }

        double IEratosthenesSieve.Search()
        {
            for (int i = 2; i < N; i++)
                for (int j = i * i; j < N; j += i)
                    NotPrime[j] = 1;

            return 0;
        }




        private void foo()
        {
            Thread[] aa = new Thread[ThreadsCount]; 


        }

    }
}
