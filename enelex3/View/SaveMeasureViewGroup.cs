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

        public List<SaveMeasureViews> Details { get; set; } = new List<SaveMeasureViews>();
    }
}
