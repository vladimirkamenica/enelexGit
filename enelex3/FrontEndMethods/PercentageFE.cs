using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.FrontEndMethods
{
    public class PercentageFE
    {
        private Model1 db;
        public PercentageFE(Model1 context = null)
        {
            db = context ?? new Model1();
        }



        public ObservableCollection<Percentage> GetPercentages()
        {
            db.Percentages.Load();
            return db.Percentages.Local;
        }
    }
}
