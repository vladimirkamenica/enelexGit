using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using enelex3.ViewModel;

namespace enelex3.SaveToBase
{
  public static  class TypeSave
    {
        public static void TypeSaveToBase(TypeCalibrationViews view, bool save, bool del,DisplayNewCalibrationsViewModel  newCalibration = null, Model1 db = null )
        {
            db = db ?? new Model1();
            var x = db.TypeCalibrations.Find(view.Id);
            x.Id = view.Id;
            x.Description = view.Description;
            x.Type = view.Type;
            x.ValueA = newCalibration == null ? view.ValueA : newCalibration.Result_A;
            x.ValueB = newCalibration == null ? view.ValueB : newCalibration.Result_B;
            x.ValueP1 = newCalibration == null ? view.ValueP1 : newCalibration.Result_P1;
            x.ValueQ1 = newCalibration == null ? view.ValueQ1 : newCalibration.Result_Q1;
            x.ValueR1 = newCalibration == null ? view.ValueR1 : newCalibration.Result_R1;
            x.ValueW = newCalibration == null ? view.ValueW : newCalibration.Result_W;
            x.IsActive = del;
            x.LastOnUpdate = DateTime.Now;
            x.DateCalibration = view.DateCalibration;
            if (save)
            {
                db.SaveChanges();
            }
            db.Dispose();
        }
    }
}
