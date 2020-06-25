using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3
{
    public class CalibrationProportionShiftingView
    {
        public int Id { get; set; }

        public double L { get; set; }

        public double P { get; set; }

        public int ID { get; set; }

        public double SumLP
        {

            get
            {
                return L - P;

            }

        }
        public bool Edit { get; set; }
    }
}
