using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using enelex3.Base;
using System.Windows;

namespace enelex3.ExcelCopyPaste
{
   public static class ExcelCopy
    {
        public static void CreateCopyList(ObservableCollection<ExcelCopyList> ListOfExcelCopyList, ObservableCollection<TrainTableView> ListOfTrainTable, ObservableCollection<MeasuresView> ListOfMeasure, ObservableCollection<ExcelCopyListMeasure> ListOfMeasuresCopyExcel, bool table)
        {
            ListOfExcelCopyList = new ObservableCollection<ExcelCopyList>();
            ListOfExcelCopyList.Clear();
            ListOfMeasuresCopyExcel = new ObservableCollection<ExcelCopyListMeasure>();
            ListOfMeasuresCopyExcel.Clear();
            if (table)
            {
                foreach (var x in ListOfTrainTable.Where(z => z.IsSelected).ToList())
                {
                    ExcelCopyList list = new ExcelCopyList();

                    list.Moisture = x.Moisture;
                    list.MoistureLabTam = x.MoistureLabTam;
                    list.MoistureLabTent = x.MoistureLabTent;
                    list.AshGE = x.AshGE;
                    list.AshLabTam = x.AshLabTam;
                    list.AshLabTent = x.AshLabTent;
                    list.CalorificGE = x.CalorificGE;
                    list.CalorificLabTam = x.CalorificLabTam;
                    list.CalorificLabTent = x.CalorificLabTent;
                    list.ErrorAsh = x.ErrorAsh.ToString("N2");
                    list.ErrorCalorific = x.ErrorCalorific.ToString("N2");
                    list.ErrorMoisture = x.ErrorMoisture.ToString("N2");
                    list.DateRecords = x.DateRecords.ToString("dd/MM/yyyy");
                    if (x.SelectedShiftsEnum == Shift.One) list.ShiftWork = "Jedan";
                    if (x.SelectedShiftsEnum == Shift.Two) list.ShiftWork = "Dva";
                    if (x.SelectedShiftsEnum == Shift.Three) list.ShiftWork = "Tri";
                    list.NumberTrain = x.NumberTrain;

                    ListOfExcelCopyList.Add(list);
                }

            }
            else
            {
                foreach(var x in ListOfMeasure.Where(x=> x.IsSelected).ToList())
                {
                    ExcelCopyListMeasure list = new ExcelCopyListMeasure();
                    list.GeAsh = x.Ge;
                    list.LabAsh = x.Lab;
                    list.W = x.W;
                    ListOfMeasuresCopyExcel.Add(list);
                }
            }
            
            
            Copy(ListOfExcelCopyList, ListOfMeasuresCopyExcel, table);
        }
        public static void Copy(ObservableCollection<ExcelCopyList> ListOfExcelCopyList , ObservableCollection<ExcelCopyListMeasure> ListOfMeasuresCopyExcel, bool table)
        {
            string separador = "\t";
            bool pintarColumnasEnterasNull = true;
            bool viewHeader = false;
            IEnumerable<PropertyInfo> colsReales = null;
            StringBuilder sb = new StringBuilder();
            if(table)
            {
                var haeder = ListOfExcelCopyList.First();
                colsReales = pintarColumnasEnterasNull ? haeder.GetType().GetProperties() : null;

                if (ListOfExcelCopyList.Count()  > 0)
                {
                    if (viewHeader) sb.AppendLine(DevolverLineaCSV(colsReales, separador));
                    foreach (var x in ListOfExcelCopyList)
                    {
                        sb.AppendLine(DevolverLineaCSV(colsReales, separador, x));
                    }
                }
            }
            else
            {
                var haeder = ListOfMeasuresCopyExcel.First();
                colsReales = pintarColumnasEnterasNull ? haeder.GetType().GetProperties() : null;

                if (ListOfMeasuresCopyExcel.Count() > 0)
                {
                    if (viewHeader) sb.AppendLine(DevolverLineaCSV(colsReales, separador));
                    foreach (var x in ListOfMeasuresCopyExcel)
                    {
                        sb.AppendLine(DevolverLineaCSV(colsReales, separador, x));
                    }
                }
            }
            Clipboard.Clear();
            Clipboard.SetText(sb.ToString());
        }
        public static string DevolverLineaCSV(IEnumerable<PropertyInfo> columnas, string separador, object objetoValor = null)
        {
            StringBuilder sb = new StringBuilder();


            //columnas.ToList().ForEach(c => sb.Append(string.Format("{0}{1}",
            //                                                            (objetoValor == null ? c.Name : c.GetValue(objetoValor, null) ?? string.Empty)?.ToString().Replace("\n", " - "),
            //                                                            separador)));
            string header = "";
            foreach (var x in columnas)
            {


                sb.Append(string.Format("{0}{1}", (objetoValor == null ? x.Name : x.GetValue(objetoValor, null) ?? string.Empty)?.ToString().Replace("\n", " - "), separador));

            }


            sb.Remove(sb.ToString().Length - 1, 1); 

            return sb.ToString();
        }
    }  }

