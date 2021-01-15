using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.View
{
   public class MonthView
    {
        public int Month { get; set; }

        public string Description { 
            get
            {
                string month = "";
                switch(Month)
                {
                    case 1:
                        month = "Januar";
                        break;
                    case 2:
                        month = "Februar";
                        break;
                    case 3:
                        month = "Mart";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "Maj";
                        break;
                    case 6:
                        month = "Jun";
                        break;
                    case 7:
                        month = "Jul";
                        break;
                    case 8:
                        month = "Avgust";
                        break;
                    case 9:
                        month = "Septembar";
                        break;
                    case 10:
                        month = "Oktobar";
                        break;
                    case 11:
                        month = "Novembar";
                        break;
                    case 12:
                        month = "Decembar";
                        break;
                }
                return month;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is MonthView view &&
                   Month == view.Month &&
                   Description == view.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = 532656246;
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}
