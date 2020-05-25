using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    /* Linear algorithm */
    class EratosthenesSieveL : IEratosthenesSieve
    {
        public int N { get; private set; }
        public double Time { get; private set; }
        /* 0 is Prime, 1 is not Prime */
        private int[] NotPrime;

        public EratosthenesSieveL(int n)
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
    }
}
