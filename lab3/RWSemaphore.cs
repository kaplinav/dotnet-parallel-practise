
using System;
using System.Threading;

namespace lab3
{
    class RWSemaphore : RWSuper, IRWcommon
    {
        static SemaphoreSlim semaphoreFull = null;
        static SemaphoreSlim semaphoreEmpty = null;

        public RWSemaphore() : base()
        { }

        public RWSemaphore(int readersCount, int writersCount, int messagesCount) : base(readersCount, writersCount, messagesCount)
        { }

        public void Run()
        {
            semaphoreFull = new SemaphoreSlim(0, 1);
            semaphoreEmpty = new SemaphoreSlim(1, 1);

            m_threadsWriters = new Thread[m_writersCount];
            for (int i = 0; i < m_threadsWriters.Length; i++)
            {
                m_threadsWriters[i] = new Thread(toWrite);
                m_threadsWriters[i].Start();
            }

            m_threadsReaders = new Thread[m_readersCount];
            for (int i = 0; i < m_threadsReaders.Length; i++)
            {
                m_threadsReaders[i] = new Thread(toRead);
                m_threadsReaders[i].Start();
            }

            foreach (Thread t in m_threadsWriters) t.Join();
            m_readersIsFinished = true;

            foreach (Thread t in m_threadsReaders)
            {
                while (t.IsAlive)
                {
                    if (semaphoreFull.CurrentCount == 0)
                    {
                        semaphoreFull.Release();
                    }
                }
            }
            
            //foreach (Thread t in m_threadsReaders) t.Join();
        }

        public static void toRead()
        {
            while (true)
            {
                semaphoreFull.Wait();

                if (m_readersIsFinished)
                    break;

                //Console.WriteLine("Reader {0} read message {1}", Thread.CurrentThread.ManagedThreadId, m_buffer);
                semaphoreEmpty.Release();
            }
        }

        public static void toWrite()
        {
            int recorded = 0;

            while (recorded < m_messagesCount)
            {
                semaphoreEmpty.Wait();
                string message = "W" + Thread.CurrentThread.ManagedThreadId;
                m_buffer = message;
                recorded++;
                //Console.WriteLine("Writer {0} wrote message {1}", Thread.CurrentThread.ManagedThreadId, message);
                semaphoreFull.Release();
            }
        }
    }
}
