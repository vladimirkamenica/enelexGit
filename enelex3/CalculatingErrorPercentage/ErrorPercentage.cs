using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.CalculatingErrorPercentage
{
  public static  class ErrorPercentage
    {
        public static double Error(double x1, double x2)
        {
            double res = 0;
            double error = (x1 - x2) / x2 * 100;
            if (error < 0) res = error * -1;
            else res = error;
            return res;
        }
    }
}
