using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3
{
    public class CalibrationOneView
    {
        public int Id { get; set; }

        public double L { get; set; }

        public double P { get; set; }

        public double SumLP
        {

            get
            {
                return L - P;

            }

        }
    }
}
