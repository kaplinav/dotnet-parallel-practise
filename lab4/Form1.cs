using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        /* delimeter symbol for .split method */
        private const char Delimiter = ' ';
        /* trim this symbols by .trim method */
        private char[] trimSymbols = { ',', '.', '-', '?', '!', ':', ';', '\t' };
        private const string TextFileFilter = "text files | *.txt";
        /* selected file */
        private string m_fileName = null;
        

        public Form1()
        {
            InitializeComponent();
        }

        /* open text file for processing */
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            /* to filter folder content */
            /* show only txt files */
            openDialog.Filter = TextFileFilter;
            openDialog.Multiselect = false;

            /* open dialog for choosing text file */
            /* return if user dont choose the file */
            if (openDialog.ShowDialog(this) != DialogResult.OK)
                return;

            /* get name of selected file */
            m_fileName = openDialog.FileName;
        }

        /* get common statistics by word frequency in text */
        private void showCommonWordStat()
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* split text on words by delimiter */
            string[] fileAllWords = fileAllText.Split(Delimiter);
            /* <key - word, value - freequency of word in text > */
            Dictionary<string, uint> wordsFreq = new Dictionary<string, uint>();

            foreach (string item in fileAllWords)
            {
                string word = item.Trim(trimSymbols).ToUpper();
                uint freq = 0;
                if (wordsFreq.TryGetValue(word, out freq))
                    wordsFreq[word] = ++wordsFreq[word];
                else
                    wordsFreq.Add(word, 1);
            }

            /* sort by value descending */
            var outList = wordsFreq.ToList();
            outList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            /* result to screen */
            foreach (var item in outList)
                textOutLines.AppendText(item.Key + ": " + item.Value + Environment.NewLine);
        }

        /* get distribution of word by length in text */
        private void showDistributionWordLength()
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* split text on words by delimiter */
            string[] fileAllWords = fileAllText.Split(Delimiter);
            /* <key - length of word, value - freequency of word in text > */
            SortedDictionary<uint, uint> lengthFreq = new SortedDictionary<uint, uint>();

            foreach (var item in fileAllWords)
            {
                string word = item.Trim(trimSymbols).ToUpper();
                uint value = 0;
                if (lengthFreq.TryGetValue((uint)word.Length, out value))
                    lengthFreq[(uint)word.Length] = ++lengthFreq[(uint)word.Length];
                else
                    lengthFreq.Add((uint)word.Length, 1);
            }

            /* sort by value descending */
            var outList = lengthFreq.ToList();
            outList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            /* result to screen */
            foreach (var item in outList)
                textOutLines.AppendText(item.Key + ": " + item.Value + Environment.NewLine);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            

            Console.Beep();
        }
    }
}
