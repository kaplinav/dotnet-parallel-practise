using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1000; i < 10000; i *= 10)
            {
                int numbers = i;
                IEratosthenesSieve es = new EratosthenesSieveLinear(numbers);
                es.Start();

                IEratosthenesSieve esPFOne = new EratosthenesSieveParallelForOne(numbers);
                esPFOne.Start();

                IEratosthenesSieve esPLINQ = new EratosthenesSievePLINQ(numbers);
                esPLINQ.Start();
            }

            for (int i = 1000; i < 20000000; i = (i * 10) / 2)
            {
                int numbers = i;
                Console.WriteLine("n = {0}", numbers);
                int threadsCount = 7;
                Console.WriteLine("threads = {0}", threadsCount);

                /* Linear algorithm */
                IEratosthenesSieve es = new EratosthenesSieveLinear(numbers);
                es.Start();
                Console.WriteLine("Linear algorithm: t = {0}", es.mWorkTime);
                
                /* parallel algorithm 1 */
                IEratosthenesSieve esPOne = new EratosthenesSieveParallelOne(numbers, threadsCount);
                esPOne.Start();
                Console.WriteLine("Parallel One: t = {0}", esPOne.mWorkTime);

                /* parallel algorithm 2 */
                IEratosthenesSieve esPTwo = new EratosthenesSieveParallelTwo(numbers, threadsCount);
                esPTwo.Start();
                Console.WriteLine("Parallel Two: t = {0}", esPTwo.mWorkTime);

                /* parallel algorithm 3 */
                IEratosthenesSieve esPThree = new EratosthenesSieveParallelThree(numbers);
                esPThree.Start();
                Console.WriteLine("Parallel Three: t = {0}", esPThree.mWorkTime);
                
                /* parallel algorithm 4 */
                IEratosthenesSieve esPFour = new EratosthenesSieveParallelFour(numbers, threadsCount);
                esPFour.Start();
                Console.WriteLine("Parallel Four: t = {0}", esPFour.mWorkTime);

                /* Parallel For */
                IEratosthenesSieve esPFOne = new EratosthenesSieveParallelForOne(numbers);
                esPFOne.Start();
                Console.WriteLine("ParallelFor One: t = {0}", esPFOne.mWorkTime);

                /* PLINQ */
                IEratosthenesSieve esPLINQ = new EratosthenesSievePLINQ(numbers);
                esPLINQ.Start();
                Console.WriteLine("PLINQ: t = {0}", esPLINQ.mWorkTime);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
