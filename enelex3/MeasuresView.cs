using enelex3.FrontEndMethods;
using System.Linq;

namespace enelex3
{

    public class MeasuresView
    {
        Model1 db = new Model1();

        public long ID { get; set; }

        public int IdSort { get; set; }

        public long Number { get; set; }

        public double Ge { get; set; }

        public double Lab { get; set; }

        public double SumMeasure
        {

            get
            {
                return Ge * Lab;
            }
        }

        public double SumGe
        {

            get
            {
                return Ge * Ge;
            }
        }

        public double P { get; set; }
        


    }
}

