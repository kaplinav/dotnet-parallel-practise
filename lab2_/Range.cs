using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_
{
    class Range
    {    
        public int mBegin { get; private set; }
        public int mEnd { get; private set; }

        public Range(int begin, int end)
        {
            mBegin = begin;
            mEnd = end;
        }
    }
}
