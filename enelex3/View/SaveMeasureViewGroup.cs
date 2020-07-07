using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;

namespace enelex3.View
{
   public class SaveMeasureViewGroup
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCalibration { get; set; }

        public int GroupID { get; set; }

        public double P { get; set; }

        public double Q { get; set; }

        public double Shifting { get; set; }

        public double ShiftingProportionP { get; set; }

        public double ShiftingProportionQ { get; set; }

        public List<SaveMeasureViews> Details { get; set; } = new List<SaveMeasureViews>();
    }
}
