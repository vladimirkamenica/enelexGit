using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.Base;

namespace enelex3.View
{
    public class ExcelCopyList
    {
        public int NumberTrain { get; set; }
        public string DateRecords { get; set; }
        public string ShiftWork { get; set; }
        public double MoistureLabTam { get; set; }

        public double MoistureLabTent { get; set; }

        public double Moisture { get; set; }
        public string ErrorMoisture { get; set; }

        public double AshLabTam { get; set; }

        public double AshLabTent { get; set; }

        public double AshGE { get; set; }

        public string ErrorAsh{ get; set; }

        public double CalorificLabTam { get; set; }

        public double CalorificLabTent { get; set; }

        public double CalorificGE { get; set; }
        public string ErrorCalorific { get; set; }
      
    }
}
