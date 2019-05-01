using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3
{
    public class Measures
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int IdSort { get; set; }

        public double Ge { get; set; }

        public double Lab { get; set; }

        public double IndexId { get; set; }

        public double P { get; set; }


    }
}
