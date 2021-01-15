using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;

namespace enelex3.FrontEndMethods
{
    public class TypeCalibrationFE
    {
        Model1 db;
        public TypeCalibrationFE(Model1 context = null)
        {
            db = context ?? new Model1();
        }
        public  List<TypeCalibrationViews> GetTypeCalibrationViews()
        {
            var ListType = (from x in db.TypeCalibrations.Include(x => x.Id)
                            where x.IsActive
                            select new TypeCalibrationViews
                            {
                                Id = x.Id,
                                Description = x.Description,
                                Type = x.Type,
                                ValueA = x.ValueA,
                                ValueB = x.ValueB,
                                ValueW = x.ValueW,
                                ValueP1 = x.ValueP1,
                                ValueQ1 = x.ValueQ1,
                                ValueR1 = x.ValueR1,
                                IsActive = x.IsActive,
                                LastOnUpdate = x.LastOnUpdate,
                                DateCalibration = x.DateCalibration,
                            }).ToList();
            return ListType;
        }
       
    }
}
