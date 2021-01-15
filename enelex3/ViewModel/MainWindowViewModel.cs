using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using enelex3.View;
using ClosedXML.Excel;
using enelex3.FrontEndMethods;
using enelex3.Alati;
using enelex3.UserControls;
using GalaSoft.MvvmLight.CommandWpf;
using enelex3.Base;
using enelex3.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using enelex3.ConvertToGrahView;
using enelex3.Helpers;
using enelex3.Interfaces;

namespace enelex3.ViewModel
{
    

public class MainWindowViewModel : ViewModelBase
    {
        public enum nameDisplayError
        {
            Absolute,
            Proportion
        }
   
        Model1 db = new Model1();
        public double FinalA { get; set; }
        public double FinalB { get; set; }

        private LogInWindow log = new LogInWindow();
        private bool Admin { get; set; }
        public MainWindowViewModel(IClosable winLog, bool admin, List<UserRegistrationViews> user)
        {
            if (winLog != null) winLog.Close();
            Admin = admin;
            ListOfUserLogIn = user;
           
        }
        private List<UserRegistrationViews> listOfUserLogIn { get; set; }
        public List<UserRegistrationViews> ListOfUserLogIn
        {
            get => listOfUserLogIn;
            set
            {
                if(listOfUserLogIn != value)
                {
                    listOfUserLogIn = value;
                    OnPropertyChanged(nameof(ListOfUserLogIn));
                }
            }
        }
        private DisplayNewCalibrationsViewModel displayNewCalibrations = new DisplayNewCalibrationsViewModel();
        public DisplayNewCalibrationsViewModel DisplayNewCalibrations
        {
            get => displayNewCalibrations;
            set
            {
                if (displayNewCalibrations != value)
                {
                    displayNewCalibrations = value;
                    OnPropertyChanged(nameof(DisplayNewCalibrations));
                }
            }
        }
        private DisplayNewCalibrationsViewModel displayCalibrations = new DisplayNewCalibrationsViewModel();
        public DisplayNewCalibrationsViewModel DisplayCalibrations
        {
            get => displayCalibrations;
            set
            {
                if (displayCalibrations != value)
                {
                    displayCalibrations = value;
                    OnPropertyChanged(nameof(DisplayCalibrations));
                }
            }
        }
        private DisplayNewCalibrationsViewModel displayCalibrationsAbsolute = new DisplayNewCalibrationsViewModel();
        public DisplayNewCalibrationsViewModel DisplayCalibrationsAbsolute
        {
            get => displayCalibrationsAbsolute;
            set
            {
                if (displayCalibrationsAbsolute != value)
                {
                    displayCalibrationsAbsolute = value;
                    OnPropertyChanged(nameof(DisplayCalibrationsAbsolute));
                }
            }
        }
        private DisplayNewCalibrationsViewModel displayCalibrationsProportion = new DisplayNewCalibrationsViewModel();
        public DisplayNewCalibrationsViewModel DisplayCalibrationsProportion
        {
            get => displayCalibrationsProportion;
            set
            {
                if (displayCalibrationsProportion != value)
                {
                    displayCalibrationsProportion = value;
                    OnPropertyChanged(nameof(DisplayCalibrationsProportion));
                }
            }
        }
        private MeasuresFE mfe;

        private ScatterLineGraphViewModel scatterGraph;
        public ScatterLineGraphViewModel ScatterGraph
        {
            get => scatterGraph;
            set
            {
                if (scatterGraph != value)
                {
                    scatterGraph = value;
                    OnPropertyChanged(nameof(ScatterGraph));
                }
            }
        }
        private ScatterLineGraphViewModel scatterGraph2;
        public ScatterLineGraphViewModel ScatterGraph2
        {
            get => scatterGraph2;
            set
            {
                if (scatterGraph2 != value)
                {
                    scatterGraph2 = value;
                    OnPropertyChanged(nameof(ScatterGraph2));
                }
            }
        }
        private ScatterLineGraphViewModel scatterGraph3;
        public ScatterLineGraphViewModel ScatterGraph3
        {
            get => scatterGraph3;
            set
            {
                if (scatterGraph3 != value)
                {
                    scatterGraph3 = value;
                    OnPropertyChanged(nameof(ScatterGraph3));
                }
            }
        }
        private ObservableCollection<MeasuresView> listOfMeasures { get; set; }

        public ObservableCollection<MeasuresView> ListOfMeasures
        {
            get => listOfMeasures;
            set
            {
                if (listOfMeasures != value)
                {
                    listOfMeasures = value;
                    OnPropertyChanged(nameof(ListOfMeasures));
                }
            }
        }
        private ObservableCollection<ExcelCopyListMeasure> listOfMeasuresCopyExcel { get; set; }

        public ObservableCollection<ExcelCopyListMeasure> ListOfMeasuresCopyExcel
        {
            get => listOfMeasuresCopyExcel;
            set
            {
                if (listOfMeasuresCopyExcel != value)
                {
                    listOfMeasuresCopyExcel = value;
                    OnPropertyChanged(nameof(ListOfMeasuresCopyExcel));
                }
            }
        }
        private List<NewCalibrationView> listOfCalibrations { get; set; }
        public List<NewCalibrationView> ListOfCalibrations
        {
            get => listOfCalibrations;
            set
            {
                if (listOfCalibrations != value)
                {
                    listOfCalibrations = value;
                    OnPropertyChanged(nameof(ListOfCalibrations));
                }
            }

        }
        private ObservableCollection<GraphView> getGraphView { get; set; }
        public ObservableCollection<GraphView> GetGraphView
        {
            get => getGraphView;
            set
            {
                if (getGraphView != value)
                {
                    getGraphView = value;
                    OnPropertyChanged(nameof(GetGraphView));
                }
            }
        }
        private List<ValueOfProportion> listOfValueOfProportion { get; set; }
        public List<ValueOfProportion> ListOfValueOfProportion
        {
            get => listOfValueOfProportion;
            set
            {
                if (listOfValueOfProportion != value)
                {
                    listOfValueOfProportion = value;
                    OnPropertyChanged(nameof(ListOfValueOfProportion));
                }
            }

        }


        private List<Percentage> listOfPercetange { get; set; }
        public List<Percentage> ListOfPercetange
        {
            get => listOfPercetange;
            set
            {
                if (listOfPercetange != value)
                {
                    listOfPercetange = value;
                    OnPropertyChanged(nameof(ListOfPercetange));
                }
            }
        }
        private SaveNewCalibrationDisplayViewModel saveNewCalibrationAbsolute { get; set; } = new SaveNewCalibrationDisplayViewModel();
        public SaveNewCalibrationDisplayViewModel SaveNewCalibrationAbsolute
        {
            get => saveNewCalibrationAbsolute;
            set
            {
                if (saveNewCalibrationAbsolute != value)
                {
                    saveNewCalibrationAbsolute = value;
                    OnPropertyChanged(nameof(SaveNewCalibrationAbsolute));
                }
            }
        }
        private SaveNewCalibrationDisplayViewModel saveNewCalibrationProportion { get; set; } = new SaveNewCalibrationDisplayViewModel();
        public SaveNewCalibrationDisplayViewModel SaveNewCalibrationProportion
        {
            get => saveNewCalibrationProportion;
            set
            {
                if (saveNewCalibrationProportion != value)
                {
                    saveNewCalibrationProportion = value;
                    OnPropertyChanged(nameof(SaveNewCalibrationProportion));
                }
            }
        }
        private ObservableCollection<TypeCalibrationViews> listOftype { get; set; }
        public ObservableCollection<TypeCalibrationViews> ListOfType
        {
            get => listOftype;
            set
            {
                if (listOftype != value)
                {
                    listOftype = value;
                    OnPropertyChanged(nameof(ListOfType));
                }
            }
        }
        private TypeCalibrationViews selectedListOftype { get; set; }
        public TypeCalibrationViews SelectedListOfType
        {
            get => selectedListOftype;
            set
            {
                if (selectedListOftype != value)
                {
                    selectedListOftype = value;

                    OnPropertyChanged(nameof(SelectedListOfType));
                    if (SelectedListOfType != null)
                    {
                        DisplayCalibrations.Result_A = SelectedListOfType.ValueA;
                        DisplayCalibrations.Result_B = SelectedListOfType.ValueB;
                        DisplayCalibrations.Result_W = SelectedListOfType.ValueW;
                        DisplayCalibrations.Result_P1 = SelectedListOfType.ValueP1;
                        DisplayCalibrations.Result_R1 = SelectedListOfType.ValueR1;
                        DisplayCalibrations.Result_Q1 = SelectedListOfType.ValueQ1;

                        DisplayNewCalibrations.Result_A = DisplayCalibrations.Result_A * Result_P;
                        DisplayNewCalibrations.Result_B = Result_P * DisplayCalibrations.Result_B + Result_Q;
                        DisplayNewCalibrations.Result_W = Result_W;
                        DisplayNewCalibrations.VisibleTXT2 = true;
                        LoadAbsolute();
                        LoadProportion();
                    }
                }
            }
        }
        private TypeCalibrationViews selectedListOfTypeSave { get; set; }
        public TypeCalibrationViews SelectedListOfTypeSave
        {
            get => selectedListOfTypeSave;
            set
            {
                if (selectedListOfTypeSave != value)
                {
                    selectedListOfTypeSave = value;

                    OnPropertyChanged(nameof(SelectedListOfTypeSave));

                }
            }
        }
        private List<CalibrationAbsoluteShifting> listOfCalibrationAbsoluteShifting { get; set; }

        public List<CalibrationAbsoluteShifting> ListOfCalibrationAbsoluteShifting
        {
            get => listOfCalibrationAbsoluteShifting;
            set
            {
                if (listOfCalibrationAbsoluteShifting != value)
                {
                    listOfCalibrationAbsoluteShifting = value;
                    OnPropertyChanged(nameof(ListOfCalibrationAbsoluteShifting));
                }
            }
        }

        private List<CalibrationProportionShiftingView> listOfCalibrationProportionShifting { get; set; }
        public List<CalibrationProportionShiftingView> ListOfCalibrationProportionShifting
        {
            get => listOfCalibrationProportionShifting;
            set
            {
                if (listOfCalibrationProportionShifting != value)
                {
                    listOfCalibrationProportionShifting = value;
                    OnPropertyChanged(nameof(ListOfCalibrationProportionShifting));
                }
            }
        }
        private MeasuresView selectedListOfMeasures { get; set; }

        public MeasuresView SelectedListOfMeasures
        {
            get => selectedListOfMeasures;
            set
            {
                if (selectedListOfMeasures != value)
                {
                    selectedListOfMeasures = value;
                    if (selectedListOfMeasures != null)
                    {
                        selectedListOfMeasures.Save = true;
                    }
                    OnPropertyChanged(nameof(SelectedListOfMeasures));
                }
            }
        }
        private CalibrationAbsoluteShifting selectedListOfCalibrationAbsoluteShifting { get; set; }

        public CalibrationAbsoluteShifting SelectedListOfCalibrationAbsoluteShifting
        {
            get => selectedListOfCalibrationAbsoluteShifting;
            set
            {
                if (selectedListOfCalibrationAbsoluteShifting != value)
                {
                    selectedListOfCalibrationAbsoluteShifting = value;
                    OnPropertyChanged(nameof(SelectedListOfCalibrationAbsoluteShifting));
                }
            }
        }
        private CalibrationProportionShiftingView selectedListOfCalibrationProportionShifting { get; set; }
        public CalibrationProportionShiftingView SelectedListOfCalibrationProportionShifting
        {
            get => selectedListOfCalibrationProportionShifting;
            set
            {
                if (selectedListOfCalibrationProportionShifting != value)
                {
                    selectedListOfCalibrationProportionShifting = value;
                    if (selectedListOfCalibrationProportionShifting != null)
                    {
                        selectedListOfCalibrationProportionShifting.Edit = true;
                    }
                    OnPropertyChanged(nameof(SelectedListOfCalibrationProportionShifting));
                }
            }
        }
        private DisplayErrorViewModel displayErrorAbsolute { get; set; } = new DisplayErrorViewModel();
        public DisplayErrorViewModel DisplayErrorAbsolute
        {
            get => displayErrorAbsolute;
            set
            {
                if (displayErrorAbsolute != value)
                {
                    displayErrorAbsolute = value;
                    OnPropertyChanged(nameof(DisplayErrorAbsolute));
                }
            }
        }
        private DisplayErrorViewModel displayErrorProportional { get; set; } = new DisplayErrorViewModel();
        public DisplayErrorViewModel DisplayErrorProportional
        {
            get => displayErrorProportional;
            set
            {
                if (displayErrorProportional != value)
                {
                    displayErrorProportional = value;
                    OnPropertyChanged(nameof(DisplayErrorProportional));
                }
            }
        }
        private CalibrationFE cfe = new CalibrationFE();
        private PercentageFE pct = new PercentageFE();
        private TypeCalibrationFE tcfe = new TypeCalibrationFE();

        public double NumberAp { get; set; }
        public double NumberBp { get; set; }
        private double newMeasureLAB { get; set; }
        public double NewMeasureLAB
        {
            get => newMeasureLAB;
            set
            {
                if (newMeasureLAB != null)
                {
                    newMeasureLAB = value;
                    OnPropertyChanged(nameof(NewMeasureLAB));
                }
            }
        }
        private double newMeasureGE { get; set; }
        public double NewMeasureGE
        {
            get => newMeasureGE;
            set
            {
                if (newMeasureGE != null)
                {
                    newMeasureGE = value;
                    OnPropertyChanged(nameof(NewMeasureGE));
                }
            }
        }

        private double newMeasureW { get; set; }
        public double NewMeasureW
        {
            get => newMeasureW;
            set
            {
                if (newMeasureW != null)
                {
                    newMeasureW = value;
                    OnPropertyChanged(nameof(NewMeasureW));
                }
            }
        }

        public double NewMeasureB { get; set; }







        public double Shifting_K { get; set; }

        public double Ps { get; set; }

        public double Qs { get; set; }

        private string logInUser { get; set; }
        public string LogInUser
        {
            get => logInUser;
            set
            {
                if (logInUser != value)
                {
                    logInUser = value;
                    OnPropertyChanged(nameof(LogInUser));
                }
            }
        }
        private int selectedIdexType { get; set; }
        public int SelectedIdexType
        {
            get => selectedIdexType;
            set
            {
                if (selectedIdexType != value)
                {
                    selectedIdexType = value;
                    OnPropertyChanged(nameof(SelectedIdexType));
                }
            }
        }
        private double sum_1 { get; set; }
        public double Sum_1
        {
            get => sum_1;
            set
            {
                if (sum_1 != value)
                {
                    sum_1 = value;
                    OnPropertyChanged(nameof(Sum_1));
                }
            }
        }
        private double sum_2 { get; set; }
        public double Sum_2
        {
            get => sum_2;
            set
            {
                if (sum_2 != value)
                {
                    sum_2 = value;
                    OnPropertyChanged(nameof(Sum_2));
                }
            }
        }
        private double sum_3 { get; set; }
        public double Sum_3
        {
            get => sum_3;
            set
            {
                if (sum_3 != value)
                {
                    sum_3 = value;
                    OnPropertyChanged(nameof(Sum_3));
                }
            }
        }
        private double sum_4 { get; set; }
        public double Sum_4
        {
            get => sum_4;
            set
            {
                if (sum_4 != value)
                {
                    sum_4 = value;
                    OnPropertyChanged(nameof(Sum_4));
                }
            }
        }
        private double sum_5 { get; set; }
        public double Sum_5
        {
            get => sum_5;
            set
            {
                if (sum_5 != value)
                {
                    sum_5 = value;
                    OnPropertyChanged(nameof(Sum_5));
                }
            }
        }
        private double result_P { get; set; }
        public double Result_P
        {
            get => result_P;
            set
            {
                if (result_P != value)
                {
                    result_P = value;
                    OnPropertyChanged(nameof(Result_P));
                }
            }
        }
        private double sum_Q1 { get; set; }
        public double Sum_Q1
        {
            get => sum_Q1;
            set
            {
                if (sum_Q1 != value)
                {
                    sum_Q1 = value;
                    OnPropertyChanged(nameof(Sum_Q1));
                }
            }
        }
        private double sum_Q2 { get; set; }
        public double Sum_Q2
        {
            get => sum_Q2;
            set
            {
                if (sum_Q2 != value)
                {
                    sum_Q2 = value;
                    OnPropertyChanged(nameof(Sum_Q2));
                }
            }
        }
        private double result_Q { get; set; }
        public double Result_Q
        {
            get => result_Q;
            set
            {
                if (result_Q != value)
                {
                    result_Q = value;
                    OnPropertyChanged(nameof(Result_Q));
                }
            }
        }


        private double number_n { get; set; }
        public double Number_n
        {
            get => number_n;
            set
            {
                if (number_n != value)
                {
                    number_n = value;
                    OnPropertyChanged(nameof(Number_n));
                }
            }
        }
      
        private double result_R { get; set; }
        public double Result_R
        {
            get => result_R;
            set
            {
                if (result_R != value)
                {
                    result_R = value;
                    OnPropertyChanged(nameof(Result_R));
                }
            }
        }
        private double result_W { get; set; }
        public double Result_W
        {
            get => result_W;
            set
            {
                if (result_W != value)
                {
                    result_W = value;
                    OnPropertyChanged(nameof(Result_W));
                }
            }
        }
    
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private int valueProgressBar { get; set; }
        public int ValueProgressBar
        {
            get => valueProgressBar;
            set
            {
                if (valueProgressBar != value)
                {
                    valueProgressBar = value;
                    OnPropertyChanged(nameof(ValueProgressBar));
                }
            }
        }
        private NewCalibrationView selectedNewCalibration;
        public NewCalibrationView SelectedNewCalibration
        {
            get => selectedNewCalibration;
            set
            {
                if (selectedNewCalibration != value)
                {
                    selectedNewCalibration = value;

                    OnPropertyChanged(nameof(SelectedNewCalibration));
                }
            }
        }

        public bool VisiblePandQ
        {
            get => Properties.Settings.Default.PandQ;
            set
            {
                Properties.Settings.Default.PandQ = value;
                OnPropertyChanged(nameof(VisiblePandQ));
            }
        }
        public bool VisibleAB
        {
            get => Properties.Settings.Default.Absolute;
            set
            {
                Properties.Settings.Default.Absolute = value;
                OnPropertyChanged(nameof(VisibleAB));
            }
        }
        public bool VisibleProportion
        {
            get => Properties.Settings.Default.Proportion;
            set
            {
                Properties.Settings.Default.Proportion = value;
                OnPropertyChanged(nameof(VisibleProportion));
            }
        }
      public ICommand CheckBoolVisibleGroupCommand => new RelayCommand(CheckBoolVisibleGroup);
        private void CheckBoolVisibleGroup()
        {
            VisiblePandQ = Properties.Settings.Default.PandQ;
            VisibleAB = Properties.Settings.Default.Absolute;
            VisibleProportion = Properties.Settings.Default.Proportion;
        }
    
        private bool expander(bool value)
        {
            if (value) return false;
            else return true;
          
        }
        public ICommand ChangeBoolPandQCommand => new RelayCommand(ChangeBoolPandQ);
        private void ChangeBoolPandQ()
        {
            VisiblePandQ = expander(VisiblePandQ);
        }
        public ICommand ChangeBoolAbsoluteCommand => new RelayCommand(ChangeBoolAbsolute);
        private void ChangeBoolAbsolute()
        {
            VisibleAB = expander(VisibleAB);
        }
        public ICommand ChangeBoolProportionalCommand => new RelayCommand(ChangeBoolProportional);
        private void ChangeBoolProportional()
        {
            VisibleProportion = expander(VisibleProportion);
        }
        
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
                db = new Model1();
                mfe = new MeasuresFE(db);
              
                ListOfMeasures = new ObservableCollection<MeasuresView>();
                ListOfMeasures.Clear();
                ListOfMeasures = mfe.GetMeasures().ToObservable();
               
            if (ListOfMeasures.Count > 0)
            {
                var maxId = ListOfMeasures.Count;
                NewMeasureB = maxId + 1;
                Number_n = maxId;
                Result_W = ListOfMeasures.Sum(x => x.W) / maxId;
                Sum_1 = maxId * ListOfMeasures.Sum(x => x.SumMeasure);
                Sum_2 = ListOfMeasures.Sum(x => x.Ge);
                Sum_3 = ListOfMeasures.Sum(x => x.Lab);
                Sum_4 = ListOfMeasures.Sum(x => x.SumGe) * maxId;
                Sum_5 = ListOfMeasures.Sum(x => x.Ge) * ListOfMeasures.Sum(x => x.Ge);
                var gorep = Sum_1 - Sum_2 * Sum_3;
                var dolep = Sum_4 - Sum_5;

                Result_P = gorep / dolep;
                Sum_Q1 = ListOfMeasures.Sum(x => x.Lab);

                var sumQ2 = ListOfMeasures.Sum(x => x.Ge);
                Sum_Q2 = sumQ2 * Result_P;

                var goreq = Sum_Q1 - Sum_Q2;
                Result_Q = goreq / maxId;
                var x1 = ListOfMeasures.Sum(x => x.SumGe);
                var y = ListOfMeasures.Sum(x => x.LabLab);
                var r = 1 - (x1 / y);

                var sx = ListOfMeasures.Sum(x => x.Ge) / maxId;
                var sy = ListOfMeasures.Sum(x => x.Lab) / maxId;

                CoefficientR();


            }
           
                
        }
        private void CoefficientR()
        {
            if(ListOfMeasures.Count > 0)
            {
                var n = ListOfMeasures.Count();
                var x1 = ListOfMeasures.Sum(x => x.GeLab);
                var x2 = ListOfMeasures.Sum(x => x.Ge) * ListOfMeasures.Sum(x => x.Lab);
                var x3 = x2 / n;
                var SPxy = x1 - x3;
                var x4 = ListOfMeasures.Sum(x => x.SumGe);
                var x5 = ListOfMeasures.Sum(x => x.Ge) * ListOfMeasures.Sum(x => x.Ge);
                var x6 = x5 / n;
                var SKxx = x4 - x6;
                var x7 = ListOfMeasures.Sum(x => x.LabLab);
                var x8 = ListOfMeasures.Sum(x => x.Lab) * ListOfMeasures.Sum(x => x.Lab);
                var x9 = x8 / n;
                var SKyy = x7 - x9;
                var x10 = SKxx * SKyy;
                var r = SPxy / Math.Sqrt(x10);
                Result_R = r * r;

                var x11 = SKyy - (Result_P * SPxy);
                var x12 = x11 / (n - 2);
                DisplayErrorAbsolute.Error_Calibration = Math.Sqrt(x12);
                DisplayErrorProportional.Error_Calibration = Math.Sqrt(x12);
            }
         }
        private void LoadGraphPandQ()
        {
        ScatterGraph = new ScatterLineGraphViewModel();
        ScatterGraph.SetMeasureViewToGraph(ListOfMeasures, Result_P, Result_Q,Result_R);
        }
        public ICommand LoadComboTypeCommand => new RelayCommand(LoadComboType);
        public void LoadComboType()
        {
            ListOfType = new ObservableCollection<TypeCalibrationViews>();
            ListOfType.Clear();
            ListOfType = tcfe.GetTypeCalibrationViews().ToObservable();
            if (ListOfType.Count() > 0)
            {
                SelectedListOfType = ListOfType[0];
            }
        }
      
        public ICommand LoadProgressBarCommand => new RelayCommand(LoadPorogressBar);
        private void LoadPorogressBar()
        {
            backgroundWorker.DoWork += (s, e) =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    
                    System.Threading.Thread.Sleep(100);
                    ValueProgressBar = i;
                }
            };
            backgroundWorker.RunWorkerAsync();
        }
        public ICommand LoadAbsoluteCommand => new RelayCommand(LoadAbsolute);
        private void LoadAbsolute()
        {
            Shifting_K = DisplayErrorAbsolute.CheckAbsoluteShift();
            DisplayCalibrationsAbsolute.Result_A = DisplayNewCalibrations.Result_A;
            var ukupno = -DisplayNewCalibrations.Result_B + Shifting_K;
            var pozitivno = -1 * ukupno;
            DisplayCalibrationsAbsolute.Result_B = pozitivno;
            DisplayCalibrationsAbsolute.Result_W = Result_W;
            DisplayCalibrationsAbsolute.VisibleTXT2 = false;
        }
      
      
        public ICommand LoadGraphAbsoluteCommand => new RelayCommand(LoadGraphAbsolute);
        private void LoadGraphAbsolute()
        {
            Shifting_K = DisplayErrorAbsolute.CheckAbsoluteShift();
            ScatterGraph2 = new ScatterLineGraphViewModel();
            ScatterGraph2.SetMeasureViewToGraph2(ListOfMeasures, Result_P, Result_Q, Shifting_K,Result_R);
        }
        public ICommand LoadProportionCommand => new RelayCommand(LoadProportion);
        private void LoadProportion()
        {
            ListOfCalibrationProportionShifting = new List<CalibrationProportionShiftingView>();
            ListOfCalibrationProportionShifting.Clear();
            ListOfCalibrationProportionShifting = cfe.GetCalibrationOnes();
            
            if (ListOfCalibrationProportionShifting.Count > 1)
            {
                var a = DisplayNewCalibrations.Result_A;
                var agore = ListOfCalibrationProportionShifting[1].L - ListOfCalibrationProportionShifting[0].L;
                var adole = ListOfCalibrationProportionShifting[1].P - ListOfCalibrationProportionShifting[0].P;
                var deljenje = agore / (adole);
                DisplayCalibrationsProportion.Result_A = a * deljenje;
                var bgore = ListOfCalibrationProportionShifting[0].P + DisplayNewCalibrations.Result_B;
                var deljenjeb = bgore / a;
                var l1 = ListOfCalibrationProportionShifting[0].L;
                DisplayCalibrationsProportion.Result_B= DisplayCalibrationsProportion.Result_A * deljenjeb - l1;
                DisplayCalibrationsProportion.Result_W = Result_W;
                DisplayCalibrationsProportion.VisibleTXT = true;
                DisplayCalibrationsProportion.VisibleTXT2 = false;
                Ps = ListOfCalibrationProportionShifting[0].SumLP;
                Qs = ListOfCalibrationProportionShifting[1].SumLP;
            
            }
        }
        private void LoadGraphProportion()
        {
            ScatterGraph3 = new ScatterLineGraphViewModel();
            ScatterGraph3.SetMeasureViewToGraph3(ListOfMeasures, Result_P, Result_Q, Ps, Qs, Shifting_K);
        }
        public ICommand AllLoadCommand => new RelayCommand(AllLoad);
        private void AllLoad()
        {
            Load();
            LoadGraphPandQ();
            LoadAbsolute();
            DisplayErrorAbsolute.LoadAbsolute = LoadAbsolute;
            LoadGraphAbsolute();
            LoadProportion();
            LoadGraphProportion();
                
        }
        public ICommand AllBoolLoadCommand => new RelayCommand(AllBoolLoad);
        private void AllBoolLoad()
        {
            Load();
            if (VisiblePandQ)
            {
               LoadGraphPandQ();
            }
            if (VisibleAB)
            {
                LoadAbsolute();
                DisplayErrorAbsolute.LoadAbsolute = LoadAbsolute;
                LoadGraphAbsolute();
            }
            if (VisibleProportion)
            {
                LoadProportion();
                LoadGraphProportion();
            }
           
        }
        private void RefreshNumber()
        {
            Result_W = 0;
            Result_P = 0;
            Result_R = 0;
            Result_Q = 0;
        }
        public ICommand SaveChangesCommand => new RelayCommand(SaveChanges);
        private void SaveChanges()
        {
            db.SaveChanges();
            Load();
        }
        public ICommand SaveChangesSHCommand => new RelayCommand(SaveChangesSH);
        private void SaveChangesSH()
        {
            db.SaveChanges();
            LoadProportion();
        }
        public ICommand SaveChangesABCommand => new RelayCommand(SaveChangesAB);
        private void SaveChangesAB()
        {
            db.SaveChanges();
            LoadAbsolute();
        }
        public ICommand UserRegistrationCommand => new RelayCommand(UserRegistration);
        private void UserRegistration()
        {
            if(Admin)
            {
                UserRegistrationWindow user = new UserRegistrationWindow(Admin);
                user.ShowDialog();
            }
            else
            {
                MessageBoxHelp.MessageBoxNoUser();
            }
           
        }
      public void IndexTypeCombo()
        {
            var index = SaveNewCalibrationAbsolute.SelectedIdexType;
            var index2 = SaveNewCalibrationProportion.SelectedIdexType;
            SelectedIdexType = ReturnIndex.GetIndex.Index(LoadComboType, SelectedIdexType);
            SaveNewCalibrationAbsolute.SelectedIdexType = index;
            SaveNewCalibrationProportion.SelectedIdexType = index2;
        }
       
        public ICommand SaveTypeCommand => new RelayCommand<string>(SaveType);
        private void SaveType(string x)
        {
            switch(x)
            {
                case "1":
                    if (SaveNewCalibrationAbsolute.SelectedListOfType != null)
                    {
                        SaveToBase.TypeSave.TypeSaveToBase(SaveNewCalibrationAbsolute.SelectedListOfType, true, true, DisplayCalibrationsAbsolute);
                        IndexTypeCombo();
                    }
                    break;
                case "2":
                    if (SaveNewCalibrationProportion.SelectedListOfType != null)
                    {
                        SaveToBase.TypeSave.TypeSaveToBase(SaveNewCalibrationProportion.SelectedListOfType, true, true, DisplayCalibrationsProportion);
                        IndexTypeCombo();
                    }
                    break;
            }
        }
        public ICommand TypeCommand => new RelayCommand(Type);
        private void Type()
        {
            TypeCalibrationWindow type = new TypeCalibrationWindow(IndexTypeCombo);
            type.ShowDialog();
           
          
        }
      
        public ICommand CloseCommand => new RelayCommand(CloseWin);
        private void CloseWin()
        {
            LogInWindow log1 = new LogInWindow();
            log1.ShowDialog();
            App.Current.Shutdown();
        }
        public ICommand LogOutCommand => new RelayCommand<IClosable>(LogOut);
        private void LogOut(IClosable win)
        {
            if (win != null) win.Close();
        }
        public ICommand EditNewCommand => new RelayCommand(EditNew);
        private void EditNew()
        {
            if (ListOfCalibrations.Count <= 0)
            {
                if (NumberAp > 0 && NumberBp > 0)
                {
                    var resP = new NewCalibration();
                    resP.NumberA = NumberAp;
                    resP.NumberB = NumberBp;
                    if (resP != null)
                    {
                        db.NewCalibrations.Add(resP);
                        db.SaveChanges();
                    }
                    Load();
                }
            }
           
        }
        public ICommand DelNewCommand => new RelayCommand(DelNew);
        public void DelNew()
        {
            if (SelectedNewCalibration != null)
            {
                var id = SelectedNewCalibration.Id;
                var x = db.NewCalibrations.Find(id);
                db.NewCalibrations.Remove(x);
                try
                {
                    db.SaveChanges();
                }
                catch
                {

                }
                ListOfCalibrations.Remove(ListOfCalibrations.FirstOrDefault(z => z.Id == id));

            }
            Load();
        }
        public ICommand AddProportionCommand => new RelayCommand(AddProportion);
        private void AddProportion()
        {
            if (ListOfCalibrationProportionShifting.Count <= 1)
            {
                AddCalibrationOne ack = new AddCalibrationOne();
                ack.ShowDialog();
                var resOne = ack.resOne;
                if (resOne != null)
                {
                    db.CalibrationProportionShiftings.Add(resOne);
                    db.SaveChanges();
                    Load();
                }
            }
        }
        public ICommand DelMeasureCommand => new RelayCommand(DelMeasure);
        private void DelMeasure()
        {
            if (MessageBoxHelp.MessageBoxYesOrNO())
            {
                List<long> ids = new List<long>();

                foreach (var x in ListOfMeasures.Where(x => x.IsSelected))
                {
                    var id = x.ID;
                    ids.Add(id);
                }
                foreach (var id in ids)
                {
                    var izbaze = db.Measures.Find(id);
                    db.Measures.Remove(izbaze);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelp.MessageBoxError();
                    }
                    ListOfMeasures.Remove(ListOfMeasures.FirstOrDefault(x => x.ID == id));
                }
                RefreshNumber();
                AllBoolLoad();
                LoadComboType();
               
            }
          
               
           
        }
        public ICommand EditMeasureCommand => new RelayCommand(EditMeasure);
        private void EditMeasure()
        {
            foreach (var x in ListOfMeasures.Where(x => x.Save))
                 {
                   if (x != null)
               
                    {
                        CopyMeasureViewToBase(x, true);
                        x.Save = false;
                    }
            }
            RefreshNumber();
              AllBoolLoad();
        }

        private void CopyMeasureViewToBase(MeasuresView input, bool saveDB, Model1 db = null)
        {

            db = db ?? new Model1();
            var x = db.Measures.Find(input.ID);
            x.ID = input.ID;
            x.Ge = input.Ge;
            x.Lab = input.Lab;
            x.W = input.W;
            x.Save = input.Save;
            if (saveDB)
            {
                db.SaveChanges();
            }
            db.Dispose();

        }

        public ICommand ExcelCommand => new RelayCommand(Excel);
        private void Excel()
        {
           
            XLWorkbook eksel = new XLWorkbook();

            DataTable dtMeasure = new DataTable();

            if (ListOfMeasures.Count > 0)
            {
                dtMeasure.Columns.Add(new DataColumn("Broj uzorka [n]", typeof(double)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo x [GE]", typeof(double)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo y [LAB]", typeof(double)));
                dtMeasure.Columns.Add(new DataColumn("Vlaga [W]", typeof(double)));

                foreach (var z in ListOfMeasures)
                {
                    if (z.GetType() != typeof(MeasuresView)) continue;
                    MeasuresView x = (MeasuresView)z;
                    DataRow dr = dtMeasure.NewRow();

                    dr[0] = x.Index;
                    dr[1] = x.Ge;
                    dr[2] = x.Lab;
                    dr[3] = x.W;

                    dtMeasure.Rows.Add(dr);

                }

            }
            var listaSh2 = new Dictionary<DataTable, string>();

            listaSh2.Add(dtMeasure, "Eneleks kalibracija");

            Tools.SaveExcelFile(listaSh2,true);

        }
     
        public ICommand AddMeasureCommand => new RelayCommand(AddMeasure);
        private void AddMeasure()
        {
            if (NewMeasureGE > 0 && NewMeasureLAB > 0 & NewMeasureW > 0)
            {
                var res = new Measure();
                res.Description = "Uneto na dugme";
                res.Lab = NewMeasureLAB;
                res.Ge = NewMeasureGE;
                res.W = NewMeasureW;
                if (res != null)
                {
                    db.Measures.Add(res);
                    db.SaveChanges();
                }
                AllLoad();
                NewMeasureGE = 0;
                NewMeasureLAB = 0;
                NewMeasureW = 0;
            }
           
        }

   
        private void ListOfCalibrationEdit(NewCalibrationView view, bool Save, Model1 db = null)
        {
            db = db ?? new Model1();
            var x = db.NewCalibrations.Find(view.Id);
            x.Id = view.Id;
            x.NumberA = view.NumberA;
            x.NumberB = view.NumberB;
            if (Save)
            {
                db.SaveChanges();
            }
            db.Dispose();
        }
        public ICommand EditNewTypeCommand => new RelayCommand(EditNewType);
        private void EditNewType()
        {
         
            if (ListOfCalibrations.Count > -1)
            {
                ListOfCalibrationEdit(ListOfCalibrations[0], true);
            }
            Load();
        }

        private void CopyOneViewToBase(CalibrationProportionShiftingView input, bool saveDB, Model1 db = null)
        {

            db = db ?? new Model1();
            var x = db.CalibrationProportionShiftings.Find(input.Id);
            x.Id = input.Id;
            x.L = input.L;
            x.P = input.P;
            if (saveDB)
            {
                db.SaveChanges();
            }
            db.Dispose();

        }
        public ICommand UpDateProportionCommand => new RelayCommand(UpDateProportion);
        private void UpDateProportion()
        {
            foreach(var x in ListOfCalibrationProportionShifting.Where(x=> x.Edit))
            {
                if(x != null)
                {
                    CopyOneViewToBase(x,true);
                    x.Edit = false;
                }
            }
            LoadProportion();
            LoadGraphProportion();
        }
        public double NumberL { get; set; }
        public double NumberP { get; set; }
        public ICommand DelProportionCommand => new RelayCommand(DelProportion);
        private void DelProportion()
        {
          
            if (SelectedListOfCalibrationProportionShifting != null)
            {
                var x = db.CalibrationProportionShiftings.Find(SelectedListOfCalibrationProportionShifting.Id);
                db.CalibrationProportionShiftings.Remove(x);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    MessageBoxHelp.MessageBoxError();
                }
                ListOfCalibrationProportionShifting.Remove(ListOfCalibrationProportionShifting.FirstOrDefault(y => y.Id == SelectedListOfCalibrationProportionShifting.Id));
                Load();
            }
        }
        private void Button_Click_11()
        {
            AddMeasures add = new AddMeasures();
            add.ShowDialog();
        }
        public ICommand SaveMeasureCommand => new RelayCommand(SaveMeasure);
        private void SaveMeasure()
        {
            SaveTransWin save = new SaveTransWin(ListOfMeasures, Shifting_K, Result_P,Result_Q,Ps,Qs);
            save.ShowDialog();
        }
        public ICommand SaveWinCommand => new RelayCommand(SaveWin);
        private void SaveWin()
        {
            SaveCalibrationWindow save = new SaveCalibrationWindow(Load);
            save.ShowDialog();
        }
        public ICommand ExcelImportCommand => new RelayCommand(ExcelImport);
        private void ExcelImport()
        {
            ExcelImportWindows excel = new ExcelImportWindows(AllBoolLoad,true,false);
            excel.ShowDialog();
            IndexTypeCombo();
        }
        public ICommand TrainCommand => new RelayCommand(Train);
        private void Train()
        {
            TrainTableWindow train = new TrainTableWindow();
            train.Show();
          
        }
        public ICommand CopyExcelCommand => new RelayCommand(CopyExcel);
        private void CopyExcel()
        {
            ExcelCopyPaste.ExcelCopy.CreateCopyList(null, null, ListOfMeasures, ListOfMeasuresCopyExcel, false);
        }
        public ICommand PasteExcelCommand => new RelayCommand(Paste);
        private void Paste()
        {

            ExcelCopyPaste.ExcelPaste.Paste(AllBoolLoad, false);

        }
      
            

    }
}
