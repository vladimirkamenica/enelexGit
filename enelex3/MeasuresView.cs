using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3
{
    public class MeasuresView
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public double Ge { get; set; }

        public double Lab { get; set; }

        public double SumMeasure
        {

            get
            {
                return Ge * Lab;
            }
        }

        public double SumGe
        {

            get
            {
                return Ge * Ge;
            }
        }

    }
}

