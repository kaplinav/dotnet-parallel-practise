using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace lab1
{
    class Range
    {
        public int start;
        public int end;

        public Range(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }

    class Program
    {
        /* complexity value */
        static int K = 5;
        /* vectors components */
        static int[] N = { 10, 100, 1000 };
        /* threads count */
        static int[] M = { 2, 3, 4, 5, 10 };
        /* count of tests */
        static int tests = 5;
        /* source vector */
        static double[] vector;
        /* target vector */
        static double[] vectorB;
        //static double[] vector = new double[N];
        /**/
        static Thread[] threads;

        static void initializeVector()
        {
            var rand = new Random();
            
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = rand.NextDouble();
            }
        }

        static void forWithoutComplexity(object o)
        {
            var range = (Range)o;

            for (int i = range.start; i < range.end; i++)
                vectorB[i] = Math.Pow(vector[i], 1.789);

        }

        static void forWithComplexity(object o)
        {
            var range = (Range)o;

            for (int i = range.start; i < range.end; i++)
            {
                /* K - complexity value */
                for (int k = 0; k < K; k++)
                    vectorB[i] += Math.Pow(vector[i], 1.789);
            }
        }

        static void forNotBalanced(object o)
        {
            var range = (Range)o;
            
            for (int i = range.start; i < range.end; i++)
            {
                for (int j = 0; j < i; j++)
                    vectorB[i] += Math.Pow(vector[i], 1.789);
            }
        }

        static void forCircle(object o)
        {
            var offset = (int)o;

            for (int i = 0; i < vector.Length; i += threads.Length)
            {
                if ((i + offset) < vector.Length)
                {
                    vectorB[i + offset] += Math.Pow(vector[i + offset], 1.789);
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("CORES: {0}", System.Environment.ProcessorCount);
            string path = @"C:\home\university\4 semester\source\dotnet-parallel-practise\lab1\result.txt";
            string text = "CORES: " + System.Environment.ProcessorCount + Environment.NewLine;
            File.WriteAllText(path, text);

            /* TASK 1 */
            /* to process of different size vectors  */
            /* linear processing */
            text = "LINEAR" + Environment.NewLine;
            File.AppendAllText(path, text);
            int[] N1 = { 10, 100, 1000, 1000000 };
            for (int i = 0; i < N1.Length; i++)
            {
                vector = new double[N1[i]];
                vectorB = new double[N1[i]];
                /* fill the vector */
                initializeVector();
                /* total time for tests */
                double totalTime = 0;

                for (int j = 0; j < tests; j++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    forWithComplexity(new Range(0, vector.Length));
                    
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;

                    if (j > 0)
                        totalTime += ts.TotalMilliseconds; 
                }

                text = "time for n=" + N1[i] + " " + (totalTime / tests) + Environment.NewLine;
                File.AppendAllText(path, text);
                Console.WriteLine("time for n={0} {1}", N1[i], (totalTime / tests));
            }

            /* TASK 2 */
            /* TASK 3 */
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("PARALLEL: RANGE WITHOUT COMPLEXITY");
            text = "PARALLEL: RANGE WITHOUT COMPLEXITY" + Environment.NewLine;
            File.AppendAllText(path, text);
            /* to process of different size vectors  */
            /* parallel processing */
            for (int i = 0; i < N1.Length; i++)
            {
                vector = new double[N1[i]];
                vectorB = new double[N1[i]];
                /* fill the vector */
                initializeVector();

                /**/
                for (int j = 0; j < M.Length; j++)
                {
                    /* define count of threads = M */
                    threads = new Thread[M[j]];
                    /* define count of vector elements for each thread */
                    int partLength = vector.Length / M[j];
                    /* total time for tests */
                    double totalTime = 0;
                    /* tests */
                    for (int h = 0; h < tests; h++)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        for (int k = 0; k < threads.Length; k++)
                        {
                            int start = k * partLength;
                            int end = start + partLength;

                            threads[k] = new Thread(forWithoutComplexity);
                            threads[k].Start(new Range(start, end));
                        }


                        foreach (Thread t in threads)
                            t.Join();

                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;

                        if (h > 0)
                            totalTime += ts.TotalMilliseconds;
                    }

                    text = "time for n=" + N1[i] + " m=" + M[j] + " " + (totalTime / tests) + Environment.NewLine;
                    File.AppendAllText(path, text);
                    Console.WriteLine("time for n={0} m={1} {2}", N1[i], M[j], (totalTime / tests));
                }
            }


            /* TASK 4 */
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("PARALLEL: RANGE WITH COMPLEXITY");
            text = "PARALLEL: RANGE WITH COMPLEXITY" + Environment.NewLine;
            File.AppendAllText(path, text);
            /* to process of different size vectors  */
            /* parallel processing */
            for (int i = 0; i < N1.Length; i++)
            {
                vector = new double[N1[i]];
                vectorB = new double[N1[i]];
                /* fill the vector */
                initializeVector();

                /**/
                for (int j = 0; j < M.Length; j++)
                {
                    /* define count of threads = M */
                    threads = new Thread[M[j]];
                    /* define count of vector elements for each thread */
                    int partLength = vector.Length / M[j];
                    /* total time for tests */
                    double totalTime = 0;
                    /* tests */
                    for (int h = 0; h < tests; h++)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        for (int k = 0; k < threads.Length; k++)
                        {
                            int start = k * partLength;
                            int end = start + partLength;

                            threads[k] = new Thread(forWithComplexity);
                            threads[k].Start(new Range(start, end));
                        }


                        foreach (Thread t in threads)
                            t.Join();

                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;

                        if (h > 0)
                            totalTime += ts.TotalMilliseconds;
                    }

                    text = "time for n=" + N1[i] + " m=" + M[j] + " " + (totalTime / tests) + Environment.NewLine;
                    File.AppendAllText(path, text);
                    Console.WriteLine("time for n={0} m={1} {2}", N1[i], M[j], (totalTime / tests));
                }
            }


            /* TASK 5 */
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("PARALLEL: RANGE NOT BALANCED");
            text = "PARALLEL: RANGE NOT BALANCED" + Environment.NewLine;
            File.AppendAllText(path, text);
            /* to process of different size vectors  */
            /* parallel processing */
            for (int i = 0; i < N.Length; i++)
            {
                vector = new double[N[i]];
                /* fill the vector */
                initializeVector();

                /**/
                for (int j = 0; j < M.Length; j++)
                {
                    /* define count of threads = M */
                    threads = new Thread[M[j]];
                    /* define count of vector elements for each thread */
                    int partLength = vector.Length / M[j];
                    /* total time for tests */
                    double totalTime = 0;
                    /* tests */
                    for (int h = 0; h < tests; h++)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        for (int k = 0; k < threads.Length; k++)
                        {
                            int start = k * partLength;
                            int end = start + partLength;

                            threads[k] = new Thread(forNotBalanced);
                            threads[k].Start(new Range(start, end));
                        }


                        foreach (Thread t in threads)
                            t.Join();

                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;

                        if (h > 0)
                            totalTime += ts.TotalMilliseconds;
                    }

                    text = "time for n=" + N[i] + " m=" + M[j] + " " + (totalTime / tests) + Environment.NewLine;
                    File.AppendAllText(path, text);
                    Console.WriteLine("time for n={0} m={1} {2}", N[i], M[j], (totalTime / tests));
                }
            }

            /* TASK 6 */
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("PARALLEL: CIRCLE");
            text = "PARALLEL: CIRCLE" + Environment.NewLine;
            File.AppendAllText(path, text);
            /* to process of different size vectors  */
            /* parallel processing */

            for (int i = 0; i < N.Length; i++)
            {
                vector = new double[N[i]];
                vectorB = new double[N[i]];
                /* fill the vector */
                initializeVector();

                /**/
                for (int j = 0; j < M.Length; j++)
                {
                    /* define count of threads = M */
                    threads = new Thread[M[j]];
                    /* define count of vector elements for each thread */
                    int partLength = vector.Length / M[j];
                    /* total time for tests */
                    double totalTime = 0;
                    /* tests */
                    for (int h = 0; h < tests; h++)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        for (int k = 0; k < threads.Length; k++)
                        {
                            int start = k * partLength;
                            int end = start + partLength;

                            threads[k] = new Thread(forCircle);
                            threads[k].Start(k);
                        }

                        foreach (Thread t in threads)
                            t.Join();

                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;

                        if (h > 0)
                            totalTime += ts.TotalMilliseconds;
                    }

                    text = "time for n=" + N[i] + " m=" + M[j] + " " + (totalTime / tests) + Environment.NewLine;
                    File.AppendAllText(path, text);
                    Console.WriteLine("time for n={0} m={1} {2}", N[i], M[j], (totalTime / tests));
                }
            }



            Console.WriteLine(System.Environment.ProcessorCount);
        }

    }
}
