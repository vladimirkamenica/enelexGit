using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.View
{
    public class TypeCalibrationComboBoxView
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public double ValueA { get; set; }
        public double ValueB { get; set; }
        public double ValueW { get; set; }
        public double ValueP1 { get; set; }
        public double ValueQ1 { get; set; }
        public double ValueR1 { get; set; }

        public bool IsActive { get; set; }

        public bool Edit { get; set; }
        public DateTime LastOnUpdate { get; set; }
    }
}
