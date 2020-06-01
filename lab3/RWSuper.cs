
using System;
using System.Threading;

namespace lab3
{
    class RWSuper
    {
        protected static string m_buffer;
        /* readers */
        protected static bool m_readersIsFinished = false;
        protected static int m_readersCount;
        protected static Thread[] m_threadsReaders;
        /* writers */
        protected static int m_writersCount;
        protected static Thread[] m_threadsWriters;
        protected static int m_messagesCount;

        public RWSuper() : this(5, 5, 1)
        { }

        public RWSuper(int readersCount, int writersCount, int messagesCount)
        {
            m_readersCount = readersCount;
            m_writersCount = writersCount;
            m_messagesCount = messagesCount;

            m_readersIsFinished = false;
    }
    }
}
