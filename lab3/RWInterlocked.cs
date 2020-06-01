﻿
using System;
using System.Threading;

namespace lab3
{
    class RWInterlocked : RWSuper, IRWcommon
    {
        static bool m_bufferIsEmpty = true;
        static int m_writerId = 0;
        static int m_readerId = 0;

        public RWInterlocked() : base()
        { }

        public RWInterlocked(int readersCount, int writersCount, int messagesCount) : base(readersCount, writersCount, messagesCount)
        { }

        public void Run()
        {
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
            foreach (Thread t in m_threadsReaders) t.Join();            
        }

        public static void toRead()
        {
            while (!m_readersIsFinished)
            {
                if (!m_bufferIsEmpty)
                {   
                    Interlocked.CompareExchange(ref m_readerId, Thread.CurrentThread.ManagedThreadId, 0);

                    if (m_readerId == Thread.CurrentThread.ManagedThreadId)
                    {
                        //Console.WriteLine("Reader {0} read message {1}", Thread.CurrentThread.ManagedThreadId, m_buffer);
                        m_bufferIsEmpty = true;
                        m_readerId = 0;
                    }
                }
            }
        }

        public static void toWrite()
        {
            int recorded = 0;

            while (recorded < m_messagesCount)
            {
                if (m_bufferIsEmpty)
                {
                    Interlocked.CompareExchange(ref m_writerId, Thread.CurrentThread.ManagedThreadId, 0);
                    
                    if (m_writerId == Thread.CurrentThread.ManagedThreadId)
                    {
                        string message = "W" + Thread.CurrentThread.ManagedThreadId;
                        m_buffer = message;
                        recorded++;
                        //Console.WriteLine("Writer {0} wrote message {1}", Thread.CurrentThread.ManagedThreadId, message);
                        m_bufferIsEmpty = false;
                        m_writerId = 0;
                    }
                }
            }
        }
    }
}
