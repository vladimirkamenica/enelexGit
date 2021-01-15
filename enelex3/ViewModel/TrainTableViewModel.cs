using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.FrontEndMethods;
using enelex3.View;
using enelex3.Helpers;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using enelex3.Base;
using enelex3.Alati;
using ClosedXML.Excel;
using System.Data;
using enelex3.Windows;
using System.Windows.Data;
using System.Windows;
using System.Reflection;
using enelex3.Helpers.Excel;


namespace enelex3.ViewModel
{
    public class TrainTableViewModel : ViewModelBase
    {
        Model1 db = new Model1();
        private ObservableCollection<YearView> yearViews { get; set; }
        public ObservableCollection<YearView> YearViews
        {
            get => yearViews;
            set
            {
                if (yearViews != value)
                {
                    yearViews = value;
                    OnPropertyChanged(nameof(YearViews));
                }
            }
        }
        private ObservableCollection<ExcelCopyList> listOfExcelCopyList { get; set; }
        public ObservableCollection<ExcelCopyList> ListOfExcelCopyList
        {
            get => listOfExcelCopyList;
            set
            {
                if (listOfExcelCopyList != value)
                {
                    listOfExcelCopyList = value;
                    OnPropertyChanged(nameof(ListOfExcelCopyList));
                }
            }
        }
        private YearView selectedYearViews { get; set; }
        public YearView SelectedYearViews
        {
            get => selectedYearViews;
            set
            {
                if (selectedYearViews != value)
                {
                    selectedYearViews = value;
                    OnPropertyChanged(nameof(SelectedYearViews));
                }
            }
        }
        private ObservableCollection<MonthView> monthViews { get; set; }
        public ObservableCollection<MonthView> MonthViews
        {
            get => monthViews;
            set
            {
                if (monthViews != value)
                {
                    monthViews = value;
                    OnPropertyChanged(nameof(MonthViews));
                }
            }
        }
        private MonthView selectedMonthViews { get; set; }
        public MonthView SelectedMonthViews
        {
            get => selectedMonthViews;
            set
            {
                if (selectedMonthViews != value)
                {
                    selectedMonthViews = value;
                    OnPropertyChanged(nameof(SelectedMonthViews));
                }
            }
        }
        private string nameFileTxt { get; set; }
        public string NameFileTxt
        {
            get => nameFileTxt;
            set
            {
                if (nameFileTxt != value)
                {
                    nameFileTxt = value;

                    OnPropertyChanged(nameof(NameFileTxt));
                }
            }
        }
        private DataTable tableExcelFile { get; set; }
        public DataTable TableExcelFile
        {
            get => tableExcelFile;
            set
            {
                if (tableExcelFile != value)
                {
                    tableExcelFile = value;
                    OnPropertyChanged(nameof(TableExcelFile));
                }
            }
        }
        private DataTableCollection tableCollection;
        public DataTableCollection TableCollection
        {
            get => tableCollection;
            set
            {
                if (tableCollection != value)
                {
                    tableCollection = value;
                    OnPropertyChanged(nameof(TableCollection));
                }
            }
        }
        private ObservableCollection<string> nameSheetTxt { get; set; }
        public ObservableCollection<string> NameSheetTxt
        {
            get => nameSheetTxt;
            set
            {
                if (nameSheetTxt != value)
                {
                    nameSheetTxt = value;
                    OnPropertyChanged(nameof(NameSheetTxt));
                }
            }
        }
        public TrainTableViewModel()
        {
            Refreash();
            YearViews = Tools.GetYears(trainTables.Select(x => x.DateRecords).OrderBy(x=>x.Year).ToList());
            if (YearViews.Count > -1)
            {
                var dateNow = DateTime.Now;
                var years = Tools.GetYear(dateNow);
                var find = YearViews.FirstOrDefault(x => x.Equals(years));
                if (find != null) SelectedYearViews = find;
                else SelectedYearViews = YearViews[0];
            }
            MonthViews = Tools.GetMonths(trainTables.Select(x => x.DateRecords).OrderBy(x=> x.Month).ToList());
            if (MonthViews.Count > -1)
            {
                var dateNow = DateTime.Now;
                var month = Tools.GetMonth(dateNow);
                var find = MonthViews.FirstOrDefault(x => x.Equals(month));
                if (find != null) SelectedMonthViews = find;
                else SelectedMonthViews = MonthViews[0];
            }
            SelectedMonth = DateTime.Now.Month;
            Load();
        }
        private TrainTableFE trfe;
        private List<TrainTableView> trainTables = new List<TrainTableView>();
        public List<int> ListOfMonth => Enumerable.Range(1, 12).ToList();

        private int selectedMonth { get; set; }
        public int SelectedMonth
        {
            get => selectedMonth;
            set
            {
                if (selectedMonth != value)
                {
                    selectedMonth = value;
                    OnPropertyChanged(nameof(SelectedMonth));
                }
            }
        }
        private bool _canUserAddRows { get; set; }

        public bool _CanUserAddRows
        {
            get => _canUserAddRows;
            set
            {
                if (_canUserAddRows != value)
                {
                    _canUserAddRows = value;
                    OnPropertyChanged(nameof(_CanUserAddRows));
                }
            }
        }
        private ObservableCollection<TrainTableView> listOfTrainTable { get; set; }
        public ObservableCollection<TrainTableView> ListOfTrainTable
        {
            get => listOfTrainTable;
            set
            {
                if (listOfTrainTable != value)
                {
                    listOfTrainTable = value;
                    OnPropertyChanged(nameof(ListOfTrainTable));
                }
            }
        }
        private ObservableCollection<TrainTableView> listOfTrainTable2 { get; set; }
        public ObservableCollection<TrainTableView> ListOfTrainTable2
        {
            get => listOfTrainTable2;
            set
            {
                if (listOfTrainTable2 != value)
                {
                    listOfTrainTable2 = value;
                    OnPropertyChanged(nameof(ListOfTrainTable2));
                }
            }
        }
        private TrainTableView selectedTrainTable { get; set; }
        public TrainTableView SelectedTrainTable
        {
            get => selectedTrainTable;
            set
            {
                if (selectedTrainTable != value)
                {
                    selectedTrainTable = value;
                    if (selectedTrainTable != null) selectedTrainTable.Edit = true;

                    OnPropertyChanged(nameof(SelectedTrainTable));
                }
            }
        }
        private List<Shift> shiftsEnum;
        public List<Shift> ShiftsEnum
        {
            get => shiftsEnum = trfe.GetShifts();
            set
            {
                if (shiftsEnum != value)
                {
                    shiftsEnum = value;
                    OnPropertyChanged(nameof(ShiftsEnum));
                }
            }
        }
        private void Refreash()
        {
            db = db ?? new Model1();
            trfe = new TrainTableFE(db);
            trainTables = trfe.GetTrainTableViews().ToList();
            YearViews = Tools.GetYears(trainTables.Select(x => x.DateRecords).OrderBy(x=> x.Year).ToList());
            MonthViews = Tools.GetMonths(trainTables.Select(x => x.DateRecords).OrderBy(x => x.Month).ToList());
        }
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
            if (YearViews.Count > -1)
            {
                Refreash();
                ListOfTrainTable = new ObservableCollection<TrainTableView>();
                ListOfTrainTable.Clear();
                ListOfTrainTable = trfe.FilterOut(trainTables, SelectedYearViews, SelectedMonthViews).ToObservable();
            }

        }
        public ICommand AddToBaseCommand => new RelayCommand(AddToBase);
        private void AddToBase()
        {
            if (SelectedTrainTable != null && SelectedTrainTable.IsNewItem)
            {
                TrainTable res = new TrainTable();
                res.DateRecords = SelectedTrainTable.DateRecords;
                res.Moisture = SelectedTrainTable.Moisture;
                res.MoistureLabTam = SelectedTrainTable.MoistureLabTam;
                res.MoistureLabTent = SelectedTrainTable.MoistureLabTent;
                res.AshGE = SelectedTrainTable.AshGE;
                res.AshLabTam = SelectedTrainTable.AshLabTam;
                res.AshLabTent = SelectedTrainTable.AshLabTent;
                res.CalorificGE = SelectedTrainTable.CalorificGE;
                res.CalorificLabTam = SelectedTrainTable.CalorificLabTam;
                res.CalorificLabTent = SelectedTrainTable.CalorificLabTent;
                res.NumberTrain = SelectedTrainTable.NumberTrain;
                res.ShiftWork = SelectedTrainTable.SelectedShiftsEnum;
                res.IsActive = true;
                res.LastUpdatedOn = DateTime.Now;
                if (res != null)
                {
                    db.TrainTables.Add(res);
                    db.SaveChanges();
                    Load();
                }
            }
        }
        private void EditTrainTable(TrainTableView view, bool save, bool active, Model1 db = null)
        {
            db = db ?? new Model1();
            var x = db.TrainTables.Find(view.Id);
            x.Id = view.Id;
            x.IsActive = active;
            x.LastUpdatedOn = DateTime.Now;
            x.Moisture = view.Moisture;
            x.MoistureLabTam = view.MoistureLabTam;
            x.MoistureLabTent = view.MoistureLabTent;
            x.AshGE = view.AshGE;
            x.AshLabTam = view.AshLabTam;
            x.AshLabTent = view.AshLabTent;
            x.CalorificGE = view.CalorificGE;
            x.CalorificLabTam = view.CalorificLabTam;
            x.CalorificLabTent = view.CalorificLabTent;
            x.DateRecords = view.DateRecords;
            x.ShiftWork = view.SelectedShiftsEnum;
            x.NumberTrain = view.NumberTrain;
            if (save)
            {
                db.SaveChanges();

            }
            db.Dispose();
        }
        public ICommand DelCommand => new RelayCommand(Delete);
        private void Delete()
        {
            var xx = ListOfTrainTable.Where(x => x.IsNewItem).ToList();
            var xxx = xx;
            foreach (var del in ListOfTrainTable.Where(x => x.IsSelected).ToList())
            {
                if (del != null)
                {
                    EditTrainTable(del, true, false);
                    Load();
                }

            }

        }
        public ICommand EditCommand => new RelayCommand(Edit);
        private void Edit()
        {
            foreach (var x in ListOfTrainTable.Where(z => z.Edit).ToList())
            {
                if (x != null)
                {
                    EditTrainTable(x, true, true);
                    x.Edit = false;
                    Load();
                }
            }
        }
        public ICommand CalibrationCommand => new RelayCommand(Calibration);
        private void Calibration()
        {
            foreach (var x in ListOfTrainTable.Where(z => z.IsSelected).ToList())
            {
                if (x != null)
                {
                    Measure measure = new Measure();
                    measure.Ge = x.AshGE;
                    measure.Lab = x.AshLabTent;
                    measure.W = x.MoistureLabTent;
                    if (measure != null)
                    {
                        db.Measures.Add(measure);
                        db.SaveChanges();
                    }
                }
            }
        }
        public ICommand ExcelCommand => new RelayCommand(Excel);
        private void Excel()
        {
            DataTable dtTrain = new DataTable();

            if (ListOfTrainTable.Count > 0)
            {

                dtTrain.Columns.Add(new DataColumn("Voz", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("Datum", typeof(string)));
                dtTrain.Columns.Add(new DataColumn("Smena", typeof(string)));
                dtTrain.Columns.Add(new DataColumn("LAB Tamnava", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("LAB Tent", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("GE3030", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("△%", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("LAB Tamnava ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("LAB Tent ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("GE3030 ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("△% ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("LAB Tamnava  ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("LAB Tent  ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("GE3030  ", typeof(double)));
                dtTrain.Columns.Add(new DataColumn("△%  ", typeof(double)));
                foreach (var z in ListOfTrainTable)
                {
                    if (z.GetType() != typeof(TrainTableView)) continue;
                    TrainTableView x = (TrainTableView)z;
                    DataRow dr = dtTrain.NewRow();

                    dr[0] = x.NumberTrain;
                    dr[1] = x.DateRecords.ToString("dd/MM/yyyy");
                    if (x.SelectedShiftsEnum == Shift.One)
                    {
                        dr[2] = "Jedan";
                    }
                    else if (x.SelectedShiftsEnum == Shift.Two)
                    {
                        dr[2] = "Dva";
                    }
                    else if (x.SelectedShiftsEnum == Shift.Three)
                    {
                        dr[2] = "Tri";
                    }
                    dr[3] = x.MoistureLabTam;
                    dr[4] = x.MoistureLabTent;
                    dr[5] = x.Moisture;
                    dr[6] = x.ErrorMoisture;
                    dr[7] = x.AshLabTam;
                    dr[8] = x.AshLabTent;
                    dr[9] = x.AshGE;
                    dr[10] = x.ErrorAsh;
                    dr[11] = x.CalorificLabTam.ToString("N2");
                    dr[12] = x.CalorificLabTent.ToString("N2");
                    dr[13] = x.CalorificGE.ToString("N2");
                    dr[14] = x.ErrorCalorific;
                    dtTrain.Rows.Add(dr);

                }

            }
            var listaSh2 = new Dictionary<DataTable, string>();

            listaSh2.Add(dtTrain, "Tabela evidencije vozova");

            Tools.SaveExcelFile(listaSh2, false);

        }
        public ICommand ExcelImportCommand => new RelayCommand(ExcelTrainImport);
        private void ExcelTrainImport()
        {
            ExcelImportWindows excel = new Windows.ExcelImportWindows(Load, false, true);
            excel.ShowDialog();
        }
        public ICommand AddNewCommand => new RelayCommand(AddNew);
        private void AddNew()
        {
            AddNewItemTrain add = new AddNewItemTrain(Load);
            add.ShowDialog();
        }
        public ICommand CopyExcelCommand => new RelayCommand(CopyExcel);
        private void CopyExcel()
        {
            ExcelCopyPaste.ExcelCopy.CreateCopyList(ListOfExcelCopyList,ListOfTrainTable,null,null,true);
        }
           
        public ICommand PasteExcelCommand => new RelayCommand(Paste);
        private void Paste()
        {

            ExcelCopyPaste.ExcelPaste.Paste(Load,true);

        }
    }
}

