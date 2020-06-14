using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        static object additionLocker = new object();
        static object progressLocker = new object();
        private const int MIN_NUMBERS_COUNT = 1000;
        private const int MAX_NUMBERS_COUNT = 100000000;
        private BackgroundWorker m_BgWorker = new BackgroundWorker();
        private InputData m_inputData;

        public Form1()
        {
            InitializeComponent();

            textBoxTime.Text = "0";
            /* set numbers count initial value */
            textBoxCount.Text = MIN_NUMBERS_COUNT.ToString();

            /* set the worker events */
            InitializeBackgroundWorker();
        }

        /* Set up the BackgroundWorker object by attaching event handlers */
        private void InitializeBackgroundWorker()
        {
            m_BgWorker.WorkerReportsProgress = true;
            m_BgWorker.WorkerSupportsCancellation = true;

            m_BgWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            m_BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            m_BgWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        }

        /* start the operation which need many time */
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /* Get the BackgroundWorker that raised this event */
            BackgroundWorker worker = sender as BackgroundWorker;

            /* Assign the result of the computation
            to the Result property of the DoWorkEventArgs
            object. This is will be available to the 
            RunWorkerCompleted eventhandler */
            e.Result = (rLinear.Checked == true) ? doWorkLinear(worker, e) : doWorkParallel(worker, e);
        }

        /* this event handler deals with the results of the background operation */
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar.Value = 0;

            /* handle the case where an exception was thrown */
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);

            /* get the run time */
            if (!e.Cancelled)
                textBoxTime.Text = ((double)e.Result).ToString();

            rLinear.Enabled = true;
            rParallel.Enabled = true;
            radioAsceSort.Enabled = true;
            radioDescSort.Enabled = true;
            radioUnSort.Enabled = true;
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        /* this event handler updates the progress bar */
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        /* start the sorting if pressed */
        private void buttonStart_Click(object sender, EventArgs e)
        {
            /* clear the time label */
            textBoxTime.Text = "0";

            rLinear.Enabled = false;
            rParallel.Enabled = false;
            radioAsceSort.Enabled = false;
            radioDescSort.Enabled = false;
            radioUnSort.Enabled = false;
            buttonPlus.Enabled = false;
            buttonMinus.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            /* start the asynchronous operation */
            m_BgWorker.RunWorkerAsync();
        }

        /* stop the sorting if pressed */
        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.progressBar.Value = 0;
            /* cancel the asynchronous operation */
            m_BgWorker.CancelAsync();
        }

        private eSort getSortingType()
        {
            eSort sortingType;

            if (radioAsceSort.Checked)
                sortingType = eSort.ASCENDING;
            else if (radioDescSort.Checked)
                sortingType = eSort.DESCENDING;
            else
                sortingType = eSort.UNSORT;
        
            return sortingType;
        }
    
    /* LINEAR */
    /* this is the method that does the actual work */
    private double doWorkLinear(BackgroundWorker worker, DoWorkEventArgs e)
        {
            /* create input data source */
            m_inputData = new InputData(Int32.Parse(textBoxCount.Text), getSortingType());
            int bucketsCount = 10;

            /* to start timer */
            Stopwatch sw = new Stopwatch();
            sw.Start();

            /* create buckets */
            List<int>[] buckets = new List<int>[bucketsCount];
            for (int i = 0; i < bucketsCount; i++)
                buckets[i] = new List<int>();

            int d = m_inputData.m_numbers.Length / bucketsCount;
            /* fill buckets by appropriate numbers  */
            for (int i = 0; i < m_inputData.m_numbers.Length; i++)
            {
                int bucketIndex = (m_inputData.m_numbers[i] / d);
                buckets[bucketIndex].Add(m_inputData.m_numbers[i]);
            }

            List<int> sortedList = new List<int>();
            /* sort each bucket and add it to the result List */
            for (int i = 0; i < bucketsCount; i++)
            {
                /* cancel if stop button is pressed */
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                buckets[i].Sort();
                sortedList.AddRange(buckets[i]);

                /* eport progress as a percentage of the total task */
                worker.ReportProgress((int)((float)i / (float)bucketsCount * 100));
            }

            /* to stop timer. get time of work */
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            return ts.TotalMilliseconds;
        }

        /* PARALLEL */
        /* this is the method that does the actual work */
        private double doWorkParallel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            /* create input data source */
            m_inputData = new InputData(Int32.Parse(textBoxCount.Text), getSortingType());
            int bucketsCount = 10;

            /* to start timer */
            Stopwatch sw = new Stopwatch();
            sw.Start();

            /* create buckets */
            List<int>[] buckets = new List<int>[bucketsCount];
            Parallel.For(0, bucketsCount, index =>
            {
                buckets[index] = new List<int>();
            });
            
            int numbersPerBucket = m_inputData.m_numbers.Length / bucketsCount;
            Parallel.For(0, bucketsCount, index =>
            {
                int minElement = index * numbersPerBucket;
                int maxElement = minElement + numbersPerBucket + 1;

                for (int i = 0; i < m_inputData.m_numbers.Length; i++)
                {
                    /* add number to bucket */
                    if (m_inputData.m_numbers[i] >= minElement && m_inputData.m_numbers[i] < maxElement)
                        buckets[index].Add(m_inputData.m_numbers[i]);
                }
            });
            
            List<int> sortedList = new List<int>();
            /* sort each bucket and add it to the result List */
            Parallel.For(0, bucketsCount, (index, state) =>
            {
                /* cancel if stop button is pressed */
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    state.Break();
                }

                buckets[index].Sort();

                lock (additionLocker)
                    sortedList.AddRange(buckets[index]);

                /* report progress as a percentage of the total task */
                lock (progressLocker)
                {
                    int progress = (int)((float)index / (float)bucketsCount * 100);

                    if (progress > progressBar.Value)
                        worker.ReportProgress(progress);
                }
                
            });

            /* to stop timer. get time of work */
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            return ts.TotalMilliseconds;
        }

        /* increase numbers count */
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(textBoxCount.Text, out value);

            if (value == MAX_NUMBERS_COUNT) return;

            value *= 10;
            textBoxCount.Text = value.ToString();
        }

        /* decrease numbers count */
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(textBoxCount.Text, out value);

            if (value == MIN_NUMBERS_COUNT) return;

            value /= 10;
            textBoxCount.Text = value.ToString();
        }
    }
}