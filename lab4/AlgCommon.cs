using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class AlgCommon
    {
        /* selected file */
        protected string m_fileName = null;
        /* delimeter symbol for .split method */
        protected const char Delimiter = ' ';
        /* trim this symbols by .trim method */
        protected char[] trimSymbols = { ',', '.', '-', '?', '!', ':', ';', '\t' };

        public AlgCommon(string fileName)
        {
            m_fileName = fileName;
        }
    }
}
