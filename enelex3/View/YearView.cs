using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.View
{
   public class YearView
    {
        public int Year { get; set; }

        public string Description { get => Year.ToString(); }

        public override bool Equals(object obj)
        {
            return obj is YearView view &&
                   Year == view.Year &&
                   Description == view.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = -926616667;
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}
