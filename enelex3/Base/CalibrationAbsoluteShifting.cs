using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3
{
    public class CalibrationAbsoluteShifting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public double NumberATwo { get; set; }

        public double NumberBTwo { get; set; }
    }
}
