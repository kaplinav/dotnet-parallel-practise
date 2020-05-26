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

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (m_fileName == null)
                return;

            ILabTask task = null;

            /* choose an algorithm */
            if (rLinear.Checked)
                task = new AlgLinear(m_fileName);
            else if (rLINQ.Checked)
                task = new AlgLINQ(m_fileName);
            else if (rParallel.Checked)
                task = new AlgParallelFor(m_fileName);
            else if (rPLINQ.Checked)
                task = new AlgPLINQ(m_fileName);

            /* choose a task */
            if (rCommonStat.Checked)
                task.showCommonWordStat(textOutLines);
            else if (rTenMostFrequent.Checked)
                task.showTenMostFrequent(textOutLines);
            else if (rDistributingLength.Checked)
                task.showDistributionWordLength(textOutLines);

            Console.Beep();
        }
    }
}