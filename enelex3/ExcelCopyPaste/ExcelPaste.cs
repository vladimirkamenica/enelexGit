using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using enelex3.Base;

namespace enelex3.ExcelCopyPaste
{
    public static class ExcelPaste
    {
        public static void SaveToBasePasteList(string [] fields, Action Load, bool table)
        {
            Model1 db = new Model1();
            if(table)
            {
                var res = new TrainTable();
                res.LastUpdatedOn = DateTime.Now;
                res.IsActive = true;
                res.NumberTrain = int.Parse(fields[0]);
                DateTime date;
                if (DateTime.TryParse(fields[1], out date)) res.DateRecords = DateTime.Parse(fields[1]);
                else res.DateRecords = DateTime.Now;
                if (fields[2] == "Jedan") res.ShiftWork = Shift.One;
                if (fields[2] == "Dva") res.ShiftWork = Shift.Two;
                if (fields[2] == "Tri") res.ShiftWork = Shift.Three;
                res.MoistureLabTam = Double.Parse(fields[3]);
                res.MoistureLabTent = Double.Parse(fields[4]);
                res.Moisture = Double.Parse(fields[5]);
                res.AshLabTam = Double.Parse(fields[7]);
                res.AshLabTent = Double.Parse(fields[8]);
                res.AshGE = Double.Parse(fields[9]);
                res.CalorificLabTam = Double.Parse(fields[11]);
                res.CalorificLabTent = Double.Parse(fields[12]);
                res.CalorificGE = Double.Parse(fields[13]);
                if(res != null)
                {
                    db.TrainTables.Add(res);
                    db.SaveChanges();
                    Load?.Invoke();
                }
                
            }
            else
            {
                var res =new Measure();
                res.Ge = Double.Parse(fields[0]);
                res.Lab = Double.Parse(fields[1]);
                res.W = Double.Parse(fields[2]);
                if(res != null)
                {
                    db.Measures.Add(res);
                    db.SaveChanges();
                    Load?.Invoke();
                }
            }
           
        }
        public static void Paste(Action Load,bool table)
        {
          
            try
            {
                var data = Clipboard.GetText();
                var lines = data.Split('\n').Where(a => !string.IsNullOrWhiteSpace(a)).ToList();
                foreach (var line in lines)
                {
                    var lineDef = line;
                    if (line.Last() == '\r') lineDef = line.Remove(line.Count() - 1);
                    var fields = line.Split('\t');
                    SaveToBasePasteList(fields, Load, table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
