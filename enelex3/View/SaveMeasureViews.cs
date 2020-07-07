using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.View
{
   public class SaveMeasureViews
    {
        public int Id { get; set; }

        public int Index { get; set; }
        public double Ge { get; set; }

        public double Lab { get; set; }
        public double W { get; set; }

        public bool Save { get; set; }

        public int GroupID { get; set; }

        public string Description { get; set; }

        public double P { get; set; }

        public double Q { get; set; }

        public double Shifting { get; set; }

        public double ShiftingProportionP { get; set; }

        public double ShiftingProportionQ { get; set; }

        public DateTime DateOfCalibration { get; set; }
    }
}
