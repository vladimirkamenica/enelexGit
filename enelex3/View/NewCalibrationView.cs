using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.View
{
    public class NewCalibrationView
    {
        public int Id { get; set; }

        public double NumberA { get; set; }

        public double GetNumbera
        {
            get
            {
                return NumberA;
            }
            set
            {
                if(value == null)
                {
                    NumberA = 0;
                }
            }
        }

        public double NumberB { get; set; }
    }
}
