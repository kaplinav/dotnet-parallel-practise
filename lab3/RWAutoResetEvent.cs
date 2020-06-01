
using System;
using System.Threading;


namespace lab3
{
    class RWAutoResetEvent : RWSuper, IRWcommon
    {
        static AutoResetEvent eventFull = new AutoResetEvent(false);
        static AutoResetEvent eventEmpty = new AutoResetEvent(true);

        public RWAutoResetEvent() : base()
        { }

        public RWAutoResetEvent(int readersCount, int writersCount, int messagesCount) : base(readersCount, writersCount, messagesCount)
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

            foreach (Thread t in m_threadsReaders)
            {
                while (t.IsAlive)
                    eventFull.Set();
            }

            //foreach (Thread t in m_threadsReaders)
            //{
            //    t.Join();
            //}   
        }

        public static void toRead()
        {
            while (true)
            {
                eventFull.WaitOne();

                if (m_readersIsFinished)
                    break;

                //Console.WriteLine("Reader {0} read message {1}", Thread.CurrentThread.ManagedThreadId, m_buffer);
                eventEmpty.Set();
            }
        }

        public static void toWrite()
        {
            int recorded = 0;

            while (recorded < m_messagesCount)
            {
                eventEmpty.WaitOne();
                string message = "W" + Thread.CurrentThread.ManagedThreadId;
                m_buffer = message;
                recorded++;
                //Console.WriteLine("Writer {0} wrote message {1}", Thread.CurrentThread.ManagedThreadId, message);
                eventFull.Set();
            }
            
        }
    }
}
