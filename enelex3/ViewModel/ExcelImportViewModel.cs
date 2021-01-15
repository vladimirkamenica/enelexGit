using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.ViewModel;
using enelex3.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.IO;
using ExcelDataReader;
using System.Data;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using enelex3.Helpers;
using enelex3.Base;
using enelex3.FrontEndMethods;
using enelex3.ViewModel;

namespace enelex3.ViewModel
{
    public class ExcelImportViewModel : ViewModelBase
    {
        Model1 db = new Model1();
        private Action Load { get; set; }
        private bool calibrationVisible { get; set; }
        public bool CalibrationVisible
        {
            get => calibrationVisible;
            set
            {
                if(calibrationVisible != value)
                {
                    calibrationVisible = value;
                    OnPropertyChanged(nameof(CalibrationVisible));
                }
            }
        }
        private bool trainVisible { get; set; }
        public bool TrainVisible
        {
            get => trainVisible;
            set
            {
                if (trainVisible != value)
                {
                    trainVisible = value;
                    OnPropertyChanged(nameof(TrainVisible));
                }
            }
        }
        public ExcelImportViewModel(Action load, bool caibration,bool train)
        {
            CalibrationVisible = caibration;
            TrainVisible = train;
            Load = load;
            All = true;
        }
        private TrainTableFE trfe = new TrainTableFE();
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
        private string selectedSheetFileTxt { get; set; }
        public string SelectedSheetFileTxt
        {
            get => selectedSheetFileTxt;
            set
            {
                if (selectedSheetFileTxt != value)
                {
                    selectedSheetFileTxt = value;
                    CheckLoad();
                    OnPropertyChanged(nameof(SelectedSheetFileTxt));
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
        private DataTable tableExcelFile { get; set; }
        public DataTable TableExcelFile
        {
            get => tableExcelFile;
            set
            {
                if(tableExcelFile != value)
                {
                    tableExcelFile = value;
                    OnPropertyChanged(nameof(TableExcelFile));
                }
            }
        }
        private ObservableCollection<ImportClassView> getImportMeasure { get; set; }

        public ObservableCollection<ImportClassView> GetImportMeasure
        {
            get => getImportMeasure;
            set
            {
                if (getImportMeasure != value)
                {
                    getImportMeasure = value;
                    OnPropertyChanged(nameof(GetImportMeasure));
                }
            }
        }
        private DataTableCollection tableCollection;
        public DataTableCollection TableCollection
        {
            get => tableCollection;
            set
            {
                if(tableCollection != value)
                {
                    tableCollection = value;
                    OnPropertyChanged(nameof(TableCollection));
                }
            }
        }
        private DataTableCollection tableCollectionTrain;
        public DataTableCollection TableCollectionTrain
        {
            get => tableCollectionTrain;
            set
            {
                if (tableCollectionTrain != value)
                {
                    tableCollectionTrain = value;
                    OnPropertyChanged(nameof(TableCollectionTrain));
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
        private bool ge;
        public bool Ge
        {
            get => ge;
            set
            {
                if(ge != value)
                {
                    ge = value;
                    OnPropertyChanged(nameof(Ge));
                }
            }
        }
        private bool lab;
        public bool Lab
        {
            get => lab;
            set
            {
                if (lab != value)
                {
                    lab = value;
                    OnPropertyChanged(nameof(Lab));
                }
            }
        }
        private bool all;
        public bool All
        {
            get => all;
            set
            {
                if (all != value)
                {
                    all = value;
                    OnPropertyChanged(nameof(All));
                }
            }
        }
        private double findFrom { get; set; }
        public double FindFrom
        {
            get => findFrom;
            set
            {
                if (findFrom != value)
                {
                    findFrom = value;

                    OnPropertyChanged(nameof(FindFrom));
                }
            }
        }
        private double findTo { get; set; }
        public double FindTo
        {
            get => findTo;
            set
            {
                if (findTo != value)
                {
                    findTo = value;

                    OnPropertyChanged(nameof(FindTo));
                }
            }

        }
        private List<ImportClassView> listFindImport { get; set; }
        public List<ImportClassView> ListFindImport
        {
            get => listFindImport;
            set
            {
                if(listFindImport != value)
                {
                    listFindImport = value;
                    OnPropertyChanged(nameof(ListFindImport));
                }
            }
        }
        private void CheckTable(bool view)
        {
            var xx = ExcelFile.ExcelImport.FillExcelImport(view);
            if (view) TableCollection = xx.Item1;
            else TableCollectionTrain = xx.Item1;
            NameFileTxt = xx.Item2;
           
        }
        public ICommand OpenCommand => new RelayCommand(ExcelImport);
        private void ExcelImport()
        {
            if(CalibrationVisible)
            {
                CheckTable(CalibrationVisible);
                NameSheetTxt = ExcelFile.ExcelImport.SheetName(NameSheetTxt, TableCollection);
            }
            else
            {
                CheckTable(CalibrationVisible);
                NameSheetTxt = ExcelFile.ExcelImport.SheetName(NameSheetTxt, TableCollectionTrain);
            }
            
        }
        private void CheckLoad()
        {
            if (CalibrationVisible) LoadExcelCalibration();
            else LoadExcelTrain();
        }
     
        private void LoadExcelTrain()
        {
            try
            {
                TableExcelFile = TableCollectionTrain[SelectedSheetFileTxt];
                if (TableExcelFile != null)
                {

                    ListOfTrainTable = new ObservableCollection<TrainTableView>();
                    ListOfTrainTable.Clear();
                    for (int i = 1; i < TableExcelFile.Rows.Count; i++)
                    {
                        TrainTableView views = new TrainTableView();
                        if (TableExcelFile.Rows[i].ItemArray[0].ToString() != String.Empty)
                        {
                            var train = TableExcelFile.Rows[i].ItemArray[0].ToString();
                            views.NumberTrain = int.Parse(train);
                        }
                        else
                        {
                            views.NumberTrain = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[1].ToString() != String.Empty)
                        {
                            var date = TableExcelFile.Rows[i].ItemArray[1].ToString();
                            views.DateRecords = DateTime.Parse((string)date);
                        }
                        else
                        {
                            views.DateRecords = DateTime.Now;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[2].ToString() != String.Empty)
                        {
                            var shift = TableExcelFile.Rows[i].ItemArray[2].ToString();
                            if (shift == "Jedan") views.SelectedShiftsEnum = Shift.One;
                            if (shift == "Dva") views.SelectedShiftsEnum = Shift.Two;
                            if (shift == "Tri") views.SelectedShiftsEnum = Shift.Three;
                        }
                        else
                        {
                            views.ShiftWork = Shift.One;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[3].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[3].ToString();
                            views.MoistureLabTam = Double.Parse(value);
                        }
                        else
                        {
                            views.MoistureLabTam = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[4].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[4].ToString();
                            views.MoistureLabTent = Double.Parse(value);
                        }
                        else
                        {
                            views.MoistureLabTam = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[5].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[5].ToString();
                            views.Moisture = Double.Parse(value);
                        }
                        else
                        {
                            views.Moisture = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[7].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[7].ToString();
                            views.AshLabTam = Double.Parse(value);
                        }
                        else
                        {
                            views.AshLabTam = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[8].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[8].ToString();
                            views.AshLabTent = Double.Parse(value);
                        }
                        else
                        {
                            views.AshLabTent = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[9].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[9].ToString();
                            views.AshGE = Double.Parse(value);
                        }
                        else
                        {
                            views.AshGE = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[11].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[11].ToString();
                            views.CalorificLabTam = Double.Parse(value);
                        }
                        else
                        {
                            views.CalorificLabTam = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[12].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[12].ToString();
                            views.CalorificLabTent = Double.Parse(value);
                        }
                        else
                        {
                            views.CalorificLabTent = 0;
                        }
                        if (TableExcelFile.Rows[i].ItemArray[13].ToString() != String.Empty)
                        {
                            var value = TableExcelFile.Rows[i].ItemArray[13].ToString();
                            views.CalorificGE = Double.Parse(value);
                        }
                        else
                        {
                            views.CalorificGE = 0;
                        }
                        ListOfTrainTable.Add(views);

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
        private void LoadExcelCalibration()
        {
            if (SelectedSheetFileTxt != null)
            {
                try
                {



                    TableExcelFile = TableCollection[SelectedSheetFileTxt];
                    if (TableExcelFile != null)
                    {

                        GetImportMeasure = new ObservableCollection<ImportClassView>();
                        GetImportMeasure.Clear();
                        for (int i = 0; i < TableExcelFile.Rows.Count; i++)
                        {
                            ImportClassView views = new ImportClassView();
                            if (TableExcelFile.Rows[i].ItemArray[1] != String.Empty)
                            {
                                var ge = TableExcelFile.Rows[i].ItemArray[1];
                                views.Ge = (double)ge;
                            }
                            else
                            {
                                views.Ge = 0;
                            }
                            if (TableExcelFile.Rows[i].ItemArray[2] != String.Empty)
                            {
                                var lab = TableExcelFile.Rows[i].ItemArray[2];
                                views.Lab = (double)lab;
                            }
                            else
                            {
                                views.Lab = 0;
                            }
                            if (TableExcelFile.Rows[i].ItemArray[3].ToString() != String.Empty)
                            {
                                var w = TableExcelFile.Rows[i].ItemArray[3];
                                views.W = (double)w;
                            }
                            else
                            {
                                views.W = 0;
                            }

                            GetImportMeasure.Add(views);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public ICommand FindNumberCommand => new RelayCommand(FindNumber);
        private void FindNumber()
        {
            LoadExcelCalibration();
            ListFindImport = new List<ImportClassView>();
            ListFindImport.Clear();
            ListFindImport.AddRange(GetImportMeasure);
            if(FindFrom > 0 && FindTo > 0 && Ge == true)
            {
                ListFindImport = ListFindImport.Where(x => x.Ge >= FindFrom && x.Ge <= FindTo).ToList();
            }
            else if(FindFrom > 0 && FindTo > 0 && Lab == true)
            {
                ListFindImport = ListFindImport.Where(x => x.Lab >= FindFrom && x.Lab <= FindTo).ToList();
            }
            else if (FindFrom > 0 && FindTo > 0 && All == true)
            {
                ListFindImport = ListFindImport.Where(x => x.Lab >= FindFrom && x.Lab <= FindTo && x.Ge >= FindFrom && x.Ge <= FindTo).ToList();
            }
            GetImportMeasure = ListFindImport.ToObservable();
        }
        public ICommand ImportCommand => new RelayCommand(SaveToBase);

        private void SaveToBase()
        {
            if (CalibrationVisible) SaveToBaseCalibration();
            else SaveToBaseTrain();
        }
        private void SaveToBaseCalibration()
        {
            if(GetImportMeasure != null)
            {
                Measure measure = new Measure();
                foreach (var x in GetImportMeasure)
                {
                    if (x != null)
                    {
                        measure.Ge = x.Ge;
                        measure.Lab = x.Lab;
                        measure.W = x.W;
                        if (measure != null)
                        {
                            db.Measures.Add(measure);
                            db.SaveChanges();
                        }
                    }
                }
                Load?.Invoke();
            }
        }
        private void SaveToBaseTrain()
        {
            foreach (var x in ListOfTrainTable)
            {
                if (x != null)
                {
                    TrainTable res = new TrainTable();
                    res.DateRecords = x.DateRecords;
                    res.Moisture = x.Moisture;
                    res.MoistureLabTam = x.MoistureLabTam;
                    res.MoistureLabTent = x.MoistureLabTent;
                    res.AshGE = x.AshGE;
                    res.AshLabTam = x.AshLabTam;
                    res.AshLabTent = x.AshLabTent;
                    res.CalorificGE = x.CalorificGE;
                    res.CalorificLabTam = x.CalorificLabTam;
                    res.CalorificLabTent = x.CalorificLabTent;
                    res.NumberTrain = x.NumberTrain;
                    res.ShiftWork = x.SelectedShiftsEnum;
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
            Load?.Invoke();
          
        }
        public ICommand GetIndexCommand => new RelayCommand<DataGridRowEventArgs>(GetIndex);
        private void GetIndex(DataGridRowEventArgs e)
        {
            var x = e.Row.DataContext as ImportClassView;
            if(x != null)
            {
                x.Index = e.Row.GetIndex() + 1;
            }
        }
    }
}
