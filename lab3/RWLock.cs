using System;
using System.Threading;

namespace lab3
{
    class RWLock : RWSuper, IRWcommon
    {
        static bool m_bufferIsEmpty = true;
        /* locks for readers and writers */
        static object read = new object();
        static object write = new object();

        public RWLock() : base()
        { }

        public RWLock(int readersCount, int writersCount, int messagesCount) : base(readersCount, writersCount, messagesCount)
        { }

        public void Run()
        {
            m_threadsWriters = new Thread[m_writersCount];
            for (int i = 0; i < m_writersCount; i++)
            {
                m_threadsWriters[i] = new Thread(toWrite);
                m_threadsWriters[i].Start();
            }

            m_threadsReaders = new Thread[m_readersCount];
            for (int i = 0; i < m_readersCount; i++)
            {
                m_threadsReaders[i] = new Thread(toRead);
                m_threadsReaders[i].Start();
            }

            foreach (Thread t in m_threadsWriters) t.Join();
            m_readersIsFinished = true;
            foreach (Thread t in m_threadsReaders) t.Join();
        }

        static void toRead()
        {
            while (!m_readersIsFinished)
            {
                if (!m_bufferIsEmpty)
                {
                    lock (read)
                    {
                        if (!m_bufferIsEmpty)
                        {
                            //Console.WriteLine("Reader {0} read message {1}", Thread.CurrentThread.ManagedThreadId, m_buffer);
                            m_bufferIsEmpty = true;
                        }
                    }
                }
            }
        }

        static void toWrite()
        {
            int recorded = 0;

            while (recorded < m_messagesCount)
            {
                lock (write)
                {
                    if (m_bufferIsEmpty)
                    {
                        string message = "W" + Thread.CurrentThread.ManagedThreadId;
                        m_buffer = message;
                        recorded++;
                        //Console.WriteLine("Writer {0} wrote message {1}", Thread.CurrentThread.ManagedThreadId, message);
                        m_bufferIsEmpty = false;
                    }
                }
            }
        }
    }
}
