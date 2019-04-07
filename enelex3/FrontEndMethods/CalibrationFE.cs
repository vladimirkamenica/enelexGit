using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.FrontEndMethods
{
    public class CalibrationFE
    {
        private Model1 db;
        public CalibrationFE(Model1 context = null)
        {
            db = context ?? new Model1();
        }

        public ObservableCollection<Calibration> GetCalibrations()
        {
            db.Calibrations.Load();
            return db.Calibrations.Local;

        }

        public ObservableCollection<CalibrationTwo> GetCalibrationsTwo()
        {
            db.CalibrationTwos.Load();
            return db.CalibrationTwos.Local;

        }

        public ObservableCollection<CalibrationThree> GetCalibrationsThree()
        {
            db.CalibrationThrees.Load();
            return db.CalibrationThrees.Local;

        }
        public List<CalibrationOneView> GetCalibrationOnes()
        {
            var listone = (from x in db.CalibratonOnes.Include(x => x.Id)
                           select new CalibrationOneView
                           {
                               Id = x.Id,
                               L = x.L,
                               P = x.P,

                           }).ToList();
            return listone;

        }
    }
}