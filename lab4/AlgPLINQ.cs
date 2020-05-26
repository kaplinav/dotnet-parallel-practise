using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class AlgPLINQ : AlgCommon, ILabTask
    {
        public AlgPLINQ(string fileName) : base(fileName)
        { }

        /* get common statistics by word frequency in text */
        public void showCommonWordStat(TextBox textBox)
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* convert the string into an array of words */
            string[] words = fileAllText.ToUpper().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var outList = words
                         .AsParallel()
                         .GroupBy(w => w)
                         .OrderByDescending(ww => ww.Count())
                         .Select(ww => new { Key = ww, Value = ww.Count() });

            /* show result */
            textBox.Clear();
            foreach (var item in outList)
                textBox.AppendText(item.Key.Key + ": " + item.Value + Environment.NewLine);
        }

        /* get distribution of word by length in text */
        public void showDistributionWordLength(TextBox textBox)
        {
            /* read text from file */
            string fileAllText = File.ReadAllText(m_fileName);

            if (fileAllText == null)
                return;

            /* convert the string into an array of words */
            string[] words = fileAllText.ToUpper().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var outList = words
                         .AsParallel()
                         .GroupBy(w => w.Length)
                         .OrderByDescending(w => w.Key)
                         .Select(ww => new { Key = ww.Key, Value = ww.Count() });

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
            string[] words = fileAllText.ToUpper().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var outList = words
                         .AsParallel()
                         .GroupBy(w => w)
                         .OrderByDescending(ww => ww.Count())
                         .Take(10)
                         .Select(ww => new { Key = ww, Value = ww.Count() });

            /* show result */
            textBox.Clear();
            foreach (var item in outList)
                textBox.AppendText(item.Key.Key + ": " + item.Value + Environment.NewLine);
        }
    }
}
