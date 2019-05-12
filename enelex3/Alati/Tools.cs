using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Alati
{
    public static class Tools
    {
        public static void SaveExcelFile(Dictionary<DataTable, string> sheetData)
        {
            XLWorkbook eksel = new XLWorkbook();                     
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "xlsx";
            if (dialog.ShowDialog() == true)
            {
                foreach (var x in sheetData)
                {
                    eksel.AddWorksheet(x.Key, x.Value);
                }
                eksel.SaveAs(dialog.FileName);
            }
        }
    }
}




