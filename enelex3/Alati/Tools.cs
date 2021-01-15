using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using System.Collections.ObjectModel;

namespace enelex3.Alati
{
    public static class Tools
    {
        public static void SaveExcelFile(Dictionary<DataTable, string> sheetData, bool view)
        {
            XLWorkbook eksel = new XLWorkbook();                     
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "xlsx";
            if (dialog.ShowDialog() == true)
            {
                foreach (var x in sheetData)
                {
                    if(view)
                    {
                        eksel.AddWorksheet(x.Key, x.Value);
                        ExcelCalibration(eksel);
                    }
                    else
                    {
                        ExcelTrain(eksel, x.Key, x.Value);
                    }
                }
              eksel.SaveAs(dialog.FileName);
            }
        }
        private static void ExcelCalibration(XLWorkbook eksel)
        {
            for (int i = 1; i <= 3; i++) eksel.Worksheet(1).Column(i).AdjustToContents();
            eksel.Style.Fill.BackgroundColor = XLColor.Transparent;
            eksel.Worksheet(1).FirstRow().Cells(1, 4).Style.Fill.BackgroundColor = XLColor.FromArgb(0xddd9c4);
            eksel.Worksheet(1).Table(0).Theme = XLTableTheme.None;
            eksel.Worksheet(1).Table(0).ShowAutoFilter = false;
            eksel.Worksheet(1).Table(0).Theme = XLTableTheme.None;
            eksel.Worksheet(1).Table(0).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.LeftBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.BottomBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.TopBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.OutsideBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.LeftBorderColor = XLColor.FromArgb(0x949494);
        }
        private static void ExcelTrain(XLWorkbook eksel, DataTable dataTable, string NameSheet)
        {
            eksel.PageOptions.Margins.Top = 0;
            eksel.PageOptions.Margins.Bottom = 0;
            eksel.PageOptions.Margins.Left = 0;
            eksel.PageOptions.Margins.Right = 0;
            eksel.PageOptions.PaperSize = XLPaperSize.LetterPaper;
            eksel.PageOptions.PageOrientation = XLPageOrientation.Landscape;
           
            eksel.PageOptions.SetPagesWide(1);
            var ws = eksel.Worksheets.Add(NameSheet);
            eksel.Worksheet(1).Row(2).Cells(1, 15).Style.Fill.BackgroundColor = XLColor.FromArgb(0xddd9c4);
            eksel.Worksheet(1).Row(3).Cells(1, 15).Style.Fill.BackgroundColor = XLColor.FromArgb(0xddd9c4);
            ws.Range(2, 1, 2, 3).Merge().Value = "Osnovni podaci";
            ws.Range(2, 1, 2, 3).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            ws.Range(2, 1, 2, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(2, 4, 2, 7).Merge().Value = "Vlaga";
            ws.Range(2, 4, 2, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            ws.Range(2, 4, 2, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(2, 8, 2, 11).Merge().Value = "Pepeo";
            ws.Range(2, 8, 2, 11).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            ws.Range(2, 8, 2, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(2, 12, 2, 15).Merge().Value = "Toplotna moć";
            ws.Range(2, 12, 2, 15).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            ws.Range(2, 12, 2, 15).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(3, 1).InsertTable(dataTable.AsEnumerable());
            ws.Columns().AdjustToContents();

            var count = eksel.Worksheet(1).Table(0).RowCount();
            for (int x = 2; x <= count; x++)
            {
                eksel.Worksheet(1).Table(0).Cell(x, 7).Style.NumberFormat.NumberFormatId = 2;
                var valueMo = eksel.Worksheet(1).Table(0).Cell(x, 7).Value;
                if ((double)valueMo > 5)
                {
                    eksel.Worksheet(1).Table(0).Cell(x, 7).Style.Font.FontColor = XLColor.Red;
                    eksel.Worksheet(1).Table(0).Cell(x, 7).Style.Font.Bold = true;
                }
                eksel.Worksheet(1).Table(0).Cell(x, 11).Style.NumberFormat.NumberFormatId = 2;
                var valueAsh = eksel.Worksheet(1).Table(0).Cell(x, 11).Value;
                if((double)valueAsh > 5)
                {
                    eksel.Worksheet(1).Table(0).Cell(x, 11).Style.Font.FontColor = XLColor.Red;
                    eksel.Worksheet(1).Table(0).Cell(x, 11).Style.Font.Bold = true;
                }
                eksel.Worksheet(1).Table(0).Cell(x, 15).Style.NumberFormat.NumberFormatId = 2;
                var valuCal = eksel.Worksheet(1).Table(0).Cell(x, 15).Value;
                if ((double)valuCal > 5)
                {
                    eksel.Worksheet(1).Table(0).Cell(x, 15).Style.Font.FontColor = XLColor.Red;
                    eksel.Worksheet(1).Table(0).Cell(x, 15).Style.Font.Bold = true;
                }
            }
            for (int i = 1; i <= 15; i++) eksel.Worksheet(1).Column(i).AdjustToContents();
            eksel.Style.Fill.BackgroundColor = XLColor.Transparent;
           
            eksel.Worksheet(1).Table(0).Theme = XLTableTheme.None;
            eksel.Worksheet(1).Table(0).ShowAutoFilter = false;
            eksel.Worksheet(1).Table(0).Theme = XLTableTheme.None;
            eksel.Worksheet(1).Table(0).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            eksel.Worksheet(1).Table(0).Style.Border.LeftBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.BottomBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.TopBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.OutsideBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Border.LeftBorderColor = XLColor.FromArgb(0x949494);
            eksel.Worksheet(1).Table(0).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
         
        }
        public static void ExcelTable(DataTable GetTable)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Inserting Tables");
            var dataTable = GetTable;
            ws.Cell(7, 1).Value = "From DataTable";
            ws.Range(7, 1, 7, 4).Merge().AddToNamed("Titles");
            ws.Cell(8, 1).InsertTable(dataTable.AsEnumerable());
            ws.Columns().AdjustToContents();

            wb.SaveAs("InsertingTables.xlsx");
        }
            public static YearView GetYear(DateTime dt)
        {
            var yearView = new YearView();
            yearView.Year = dt.Year;
            return yearView;

        }
        public static ObservableCollection<YearView> GetYears(List<DateTime> dt)
        {
            ObservableCollection<YearView> year = new ObservableCollection<YearView>();
            foreach(var date in dt)
            {
                var res = GetYear(date);
                if (!year.Any(x => x.Year == date.Year)) year.Add(res);

            }
            return year;
        }
        public static MonthView GetMonth(DateTime dt)
        {
            var monthView = new MonthView();
            monthView.Month = dt.Month;
            return monthView;

        }
        public static ObservableCollection<MonthView> GetMonths(List<DateTime> dt)
        {
            ObservableCollection<MonthView> month = new ObservableCollection<MonthView>();
            foreach (var date in dt)
            {
                var res = GetMonth(date);
                if (!month.Any(x => x.Month == date.Month)) month.Add(res);

            }
            return month;
        }
    }
}




