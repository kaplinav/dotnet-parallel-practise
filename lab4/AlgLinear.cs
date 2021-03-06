﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    /* process tasks with linear algorithm */
    class AlgLinear : AlgCommon, ILabTask
    {
        public AlgLinear(string fileName) : base(fileName)
        { }

        /* get common statistics by word frequency in text */
        public void showCommonWordStat(TextBox textBox)
        { 
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* convert the string into an array of words */
            string[] fileAllWords = fileAllText.ToUpper().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            /* split text on words by delimiter */
            //string[] fileAllWords = fileAllText.Split(Delimiter);
            /* <key - word, value - freequency of word in text > */
            Dictionary<string, uint> wordsFreq = new Dictionary<string, uint>();

            foreach (string item in fileAllWords)
            {
                uint freq = 0;
                if (wordsFreq.TryGetValue(item, out freq))
                    wordsFreq[item] = ++wordsFreq[item];
                else
                    wordsFreq.Add(item, 1);
            }

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

            /* convert the string into an array of words */
            string[] fileAllWords = fileAllText.ToUpper().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            /* split text on words by delimiter */
            //string[] fileAllWords = fileAllText.Split(Delimiter);

            /* <key - length of word, value - freequency of word in text > */
            SortedDictionary<uint, uint> lengthFreq = new SortedDictionary<uint, uint>();

            foreach (var item in fileAllWords)
            {
                uint value = 0;
                if (lengthFreq.TryGetValue((uint)item.Length, out value))
                    lengthFreq[(uint)item.Length] = ++lengthFreq[(uint)item.Length];
                else
                    lengthFreq.Add((uint)item.Length, 1);
            }

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

            /* convert the string into an array of words */
            string[] fileAllWords = fileAllText.ToUpper().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            /* split text on words by delimiter */
            //string[] fileAllWords = fileAllText.Split(Delimiter);

            /* <key - word, value - freequency of word in text > */
            Dictionary<string, uint> wordsFreq = new Dictionary<string, uint>();

            foreach (string item in fileAllWords)
            {
                uint freq = 0;
                if (wordsFreq.TryGetValue(item, out freq))
                    wordsFreq[item] = ++wordsFreq[item];
                else
                    wordsFreq.Add(item, 1);
            }

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