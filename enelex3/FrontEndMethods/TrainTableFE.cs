using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.Base;
using enelex3.View;

namespace enelex3.FrontEndMethods
{
    public class TrainTableFE
    {
        Model1 db;
        public TrainTableFE(Model1 context = null)
        {
            db = context ?? new Model1();
        }

        public List<TrainTableView> GetTrainTableViews()
        {
            var train = (from x in db.TrainTables.Include(z => z.Id) where x.IsActive select new TrainTableView
            {
                Id = x.Id,
                DateRecords = x.DateRecords,
                Moisture = x.Moisture,
                MoistureLabTam = x.MoistureLabTam,
                MoistureLabTent = x.MoistureLabTent,
                AshGE = x.AshGE,
                AshLabTam = x.AshLabTam,
                AshLabTent = x.AshLabTent,
                CalorificGE = x.CalorificGE,
                CalorificLabTam = x.CalorificLabTam,
                CalorificLabTent = x.CalorificLabTent,
                SelectedShiftsEnum = x.ShiftWork,
                NumberTrain = x.NumberTrain,
                IsActive = x.IsActive,
                LastUpdatedOn = x.LastUpdatedOn
            }).ToList();
            return train;
        }
        public List<Shift>  GetShifts()
        {
            return Enum.GetValues(typeof(Shift)).Cast<Shift>().ToList();
        }

        public List<TrainTableView> FilterOut(List<TrainTableView> trainTables, YearView year, MonthView month)
        {
            var res = new List<TrainTableView>();
            res.AddRange(trainTables);
            if(res != null)
            {
                if(year != null && month != null) res = res.Where(x => x.DateRecords.Year == year.Year && x.DateRecords.Date.Month == month.Month).OrderBy(x => x.DateRecords.Year).ToList();
                if(year != null && month == null) res = res.Where(x => x.DateRecords.Year == year.Year).OrderBy(x => x.DateRecords.Year).ToList();
                if(year == null && month == null) res = res.OrderBy(x=> x.DateRecords.Year).ToList();
            }
            return res;
        }
    }
}
