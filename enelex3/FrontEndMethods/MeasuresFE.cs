using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.FrontEndMethods
{
    public class MeasuresFE

    {
        private Model1 db;
        public MeasuresFE(Model1 context = null)
        {
            db = context ?? new Model1();
        }
        public List<MeasuresView> GetMeasures()
        {
            var list = (from x in db.Measures.Include(x => x.ID)
                        select new MeasuresView
                        {
                            ID = x.ID,
                            Lab = x.Lab,
                            Ge = x.Ge,
                            Number = x.ID,
                            P = x.P,
                            W = x.W,
                           
                        }).ToList();

            return list;

        }

    }
}
