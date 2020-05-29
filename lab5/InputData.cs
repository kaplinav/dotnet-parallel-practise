using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab5
{
    enum eSort
    {
        ASCENDING,
        DESCENDING,
        UNSORT
    }

    class InputData
    {
        private int m_numbersCount;
        private eSort m_sortingType;
        public int[] m_numbers { get; private set; }

        public InputData(int numbersCount) : this(numbersCount, eSort.UNSORT)
        { }

        public InputData(int numbersCount, eSort sortingType)
        {
            m_numbersCount = numbersCount;
            m_sortingType = eSort.UNSORT;

            /* fill array with random numbers */
            fillArray();
            /* sort array by user specified type */
            sortArray();
        }

        /* fill array with random numbers */
        private void fillArray()
        {
            Random random = new Random();
            m_numbers = new int[m_numbersCount];

            for (int i = 0; i < m_numbersCount; i++)
                m_numbers[i] = random.Next(0, m_numbersCount);
        }

        /* sort array by user specified type */
        private void sortArray()
        {
            if (m_sortingType == eSort.UNSORT)
                return;

            Array.Sort(m_numbers);

            if (m_sortingType == eSort.DESCENDING)
                Array.Reverse(m_numbers);
        }
    }
}