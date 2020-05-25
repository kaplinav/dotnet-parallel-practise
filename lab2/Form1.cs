using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setInitValue();
        }

        /* set initial values */
        private void setInitValue()
        {
            labelThreads.Text = String.Format("Threads: {0}", trackBarThreads.Value);
            labelTestsCount.Text = "10";
        }

        /* press to start calculation */
        private void buttonStart_Click(object sender, EventArgs e)
        {
            IEratosthenesSieve es;

            double a = 26;
            double b = Math.Sqrt(a);
            double c = Math.Pow(b, 2);



            int[] N = { 500, 1000, 1500, 2000 };

            chartTests.Series.Clear();
            Series s1 = new Series("Linear algorithm");
            s1.ChartType = SeriesChartType.Line;
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < N.Length; i++)
            {
                
                double totalTime = 0;
                for (int j = 0; j < int.Parse(labelTestsCount.Text); j++)
                {
                    sw.Start();
                    es = new EratosthenesSieveL(N[i]);
                    es.Search();
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;

                    if (j > 0)
                        totalTime += ts.TotalMilliseconds;
                }

                //s1.Points.Add
                s1.Points.AddXY(Math.Round((totalTime / int.Parse(labelTestsCount.Text)), 3, MidpointRounding.AwayFromZero), N[i]);
            }

            

            
            
            //s1.Points.Add(2, 12);
            //s1.Points.Add(3, 4);
            //s1.Points.Add(4, 17);
            //s1.Color = Color.Green;

            chartTests.Series.Add(s1);
            //chartTests.ChartAreas["ChartArea1"].AxisX.LineColor = Color.LightGray;
            //chartTests.ChartAreas["ChartArea1"].AxisY.LineColor = Color.LightGray;
            chartTests.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartTests.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void trackBarThreads_Scroll(object sender, EventArgs e)
        {
            labelThreads.Text = String.Format("Threads: {0}", trackBarThreads.Value);
        }

        private void buttonTestMinus_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelTestsCount.Text) > 1)
                labelTestsCount.Text = "" + (int.Parse(labelTestsCount.Text) - 1);
        }

        private void buttonTestPlus_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelTestsCount.Text) < 999)
                labelTestsCount.Text = "" + (int.Parse(labelTestsCount.Text) + 1);
        }
    }
}
