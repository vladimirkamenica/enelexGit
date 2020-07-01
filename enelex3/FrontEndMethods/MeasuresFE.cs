using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;

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
                            W = x.W,
                            Description = x.Description,
                          
                           
                        }).ToList();

            return list;

        }
        public List<SaveMeasureViews> GetSaveMeasureViews()
        {
            var list = (from x in db.SaveMeasures.Include(x => x.Id)
                        select new SaveMeasureViews
                        {
                            Id = x.Id,
                            Lab = x.Lab,
                            Ge = x.Ge,
                            DateOfCalibration = x.DateOfCalibration,
                            Description = x.Description,
                            W = x.W,
                            GroupID = x.GroupID
                        }).ToList();
            return list;
        }

        public List<SaveMeasureViewGroup> GetViewGroups(List<SaveMeasureViews> views)
        {
            return views.GroupBy(x => x.GroupID).Select(x => new SaveMeasureViewGroup
                {
                    Id = x.FirstOrDefault().Id,
                    Description = x.FirstOrDefault().Description,
                    DateOfCalibration = x.FirstOrDefault().DateOfCalibration,
                    GroupID = x.FirstOrDefault().GroupID,
                    Details = x.ToList(),
                }).ToList();
        }
    }
}
