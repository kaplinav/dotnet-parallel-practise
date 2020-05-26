using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    interface ILabTask
    {
        void showCommonWordStat(TextBox textBox);
        void showTenMostFrequent(TextBox textBox);
        void showDistributionWordLength(TextBox textBox);
    }
}
