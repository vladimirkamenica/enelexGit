using enelex3.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3
{
    public class Measure : IBasicData, IDates
    {
        public Measure()
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Active = true;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public double Ge { get; set; }

        public double Lab { get; set; }

        public double IndexId { get; set; }

        public double P { get; set; }

        public string Description { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
        public long CreationUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public long UpdateUserID { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
