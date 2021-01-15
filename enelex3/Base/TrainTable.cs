using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Base
{
    public class TrainTable
    {
        public TrainTable()
        {
            DateRecords = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public DateTime DateRecords { get; set; }

        public int NumberTrain { get; set; }
        
        public double MoistureLabTam { get; set; }

        public double MoistureLabTent { get; set; }

        public double Moisture { get; set; }

        public double AshLabTam { get; set; }

        public double AshLabTent { get; set; }

        public double AshGE { get; set; }

        public double CalorificLabTam { get; set; }

        public double CalorificLabTent{ get; set; }

        public double CalorificGE { get; set; }

        public Shift ShiftWork { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
