using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    interface IEratosthenesSieve
    {
        int N { get; }
        double Time { get; }
        double Search();
    }
}
