
using System;
using System.Diagnostics;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = Environment.CurrentDirectory + "\\out.csv";
            /* columns header */
            File.WriteAllText(path, "Threads count;Lock;AutoResetEvent;Semaphore;Interlocked" + Environment.NewLine);

            for (int i = 0; i < 16; i++)
            {
                string text = null;
                /* ThreadCount */
                text = i + ";";

                /* Lock */
                TimeSpan ts;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                new RWLock(i, i, 1).Run();
                sw.Stop();
                ts = sw.Elapsed;
                text += ts.TotalMilliseconds + ";";
                //Console.WriteLine("Lock finish");

                /* AutoResetEvent */
                sw.Start();
                new RWAutoResetEvent(i, i, 1).Run();
                sw.Stop();
                ts = sw.Elapsed;
                text += ts.TotalMilliseconds + ";";
                //Console.WriteLine("AutoResetEvent finish");

                /* Semaphore */
                sw.Start();
                new RWSemaphore(i, i, 1).Run();
                sw.Stop();
                ts = sw.Elapsed;
                text += ts.TotalMilliseconds + ";";
                //Console.WriteLine("Semaphore finish");

                /* Interlocked */
                sw.Start();
                new RWInterlocked(i, i, 1).Run();
                sw.Stop();
                ts = sw.Elapsed;
                text += ts.TotalMilliseconds + Environment.NewLine;
                //Console.WriteLine("Interlocked finish");

                /* don't writing result with threads < 5 */
                if (i >= 5)
                    File.AppendAllText(path, text);
            }

            Console.WriteLine("that is all");
            Console.ReadKey();
        }
    }
}
