using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class AlgParallelFor : AlgCommon, ILabTask
    {
        public AlgParallelFor(string fileName) : base(fileName)
        { }

        /* get common statistics by word frequency in text */
        public void showCommonWordStat(TextBox textBox)
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* split text on words by delimiter */
            string[] fileAllWords = fileAllText.Split(Delimiter);
            /* <key - word, value - freequency of word in text > */
            ConcurrentDictionary<string, uint> wordsFreq = new ConcurrentDictionary<string, uint>();

            Parallel.For(0, fileAllWords.Length, index =>
            {
                string word = fileAllWords[index].Trim(trimSymbols).ToUpper();
                uint freq = 0;
                if (wordsFreq.TryGetValue(word, out freq))
                    wordsFreq[word] = ++wordsFreq[word];
                else
                    wordsFreq.TryAdd(word, 1);
            });

            /* sort by value descending */
            var outList = wordsFreq.ToList();
            outList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            /* show result */
            textBox.Clear();
            foreach (var item in outList)
                textBox.AppendText(item.Key + ": " + item.Value + Environment.NewLine);
        }

        /* get distribution of word by length in text */
        public void showDistributionWordLength(TextBox textBox)
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* split text on words by delimiter */
            string[] fileAllWords = fileAllText.Split(Delimiter);
            /* <key - length of word, value - freequency of word in text > */
            ConcurrentDictionary<uint, uint> lengthFreq = new ConcurrentDictionary<uint, uint>();

            Parallel.For(0, fileAllWords.Length, index =>
            {
                string word = fileAllWords[index].Trim(trimSymbols).ToUpper();
                uint value = 0;
                if (lengthFreq.TryGetValue((uint)word.Length, out value))
                    lengthFreq[(uint)word.Length] = ++lengthFreq[(uint)word.Length];
                else
                    lengthFreq.TryAdd((uint)word.Length, 1);
            });
            
            /* sort by value descending */
            var outList = lengthFreq.ToList();
            outList.Sort((pair1, pair2) => pair2.Key.CompareTo(pair1.Key));

            /* show result */
            textBox.Clear();
            foreach (var item in outList)
                textBox.AppendText(item.Key + ": " + item.Value + Environment.NewLine);
        }

        /* get ten most frequent word */
        public void showTenMostFrequent(TextBox textBox)
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* split text on words by delimiter */
            string[] fileAllWords = fileAllText.Split(Delimiter);
            /* <key - word, value - freequency of word in text > */
            ConcurrentDictionary<string, uint> wordsFreq = new ConcurrentDictionary<string, uint>();

            Parallel.For(0, fileAllWords.Length, index =>
            {
                string word = fileAllWords[index].Trim(trimSymbols).ToUpper();
                uint freq = 0;
                if (wordsFreq.TryGetValue(word, out freq))
                    wordsFreq[word] = ++wordsFreq[word];
                else
                    wordsFreq.TryAdd(word, 1);
            });
            
            /* sort by value descending */
            var descending = wordsFreq.ToList();
            descending.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var outList = descending.Take(10);

            /* show result */
            textBox.Clear();
            foreach (var item in outList)
                textBox.AppendText(item.Key + ": " + item.Value + Environment.NewLine);
        }
    }
}
