using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;

namespace enelex3.FrontEndMethods
{
    public class CalibrationFE
    {
        private Model1 db;
        public CalibrationFE(Model1 context = null)
        {
            db = context ?? new Model1();
        }

        public ObservableCollection<NewCalibration> GetCalibrations()
        {
            db.NewCalibrations.Load();
            return db.NewCalibrations.Local;

        }

        public ObservableCollection<CalibrationAbsoluteShifting> GetCalibrationsTwo()
        {
            db.CalibrationAbsoluteShiftings.Load();
            return db.CalibrationAbsoluteShiftings.Local;

        }

        public ObservableCollection<ValueOfProportion> GetCalibrationsThree()
        {
            db.ValueOfProportions.Load();
            return db.ValueOfProportions.Local;

        }
        public List<CalibrationProportionShiftingView> GetCalibrationOnes()
        {
            var listone = (from x in db.CalibrationProportionShiftings.Include(x => x.Id)
                           select new CalibrationProportionShiftingView
                           {
                               Id = x.Id,
                               L = x.L,
                               P = x.P,
                              
                           }).ToList();
            return listone;

        }
        public List<NewCalibrationView> calibrationViews()
        {
            var list = (from x in db.NewCalibrations.Include(x => x.Id) select new NewCalibrationView { Id = x.Id, NumberA = x.NumberA, NumberB = x.NumberB }).ToList();return list;
        }
    }
}