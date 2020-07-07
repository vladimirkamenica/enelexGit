using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Base
{
    public class SaveMeasure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public double Ge { get; set; }

        public double Lab { get; set; }
        public double W { get; set; }

        public int GroupID { get; set; }
        public bool Save { get; set; }

        public double P { get; set; }

        public double Q { get; set; }

        public double Shifting { get; set; }

        public double ShiftingProportionP { get; set; }

        public double ShiftingProportionQ { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCalibration { get; set; }
    }
}
