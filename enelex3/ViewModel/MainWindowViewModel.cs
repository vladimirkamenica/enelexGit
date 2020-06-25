using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data;
using System.Windows;
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

namespace enelex3.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        Model1 db = new Model1();
        public double FinalA { get; set; }
        public double FinalB { get; set; }

        public MainWindowViewModel()
        {
           
        }
        private MeasuresFE mfe;

        private List<MeasuresView> listOfMeasures { get; set; }

        public List<MeasuresView> ListOfMeasures
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

        private List<CalibrationAbsoluteShifting> listOfCalibrationAbsoluteShifting { get; set; }

        public  List<CalibrationAbsoluteShifting> ListOfCalibrationAbsoluteShifting
        {
            get => listOfCalibrationAbsoluteShifting;
            set
            {
                if(listOfCalibrationAbsoluteShifting != value)
                {
                    listOfCalibrationAbsoluteShifting = value;
                    OnPropertyChanged(nameof(ListOfCalibrationAbsoluteShifting));
                }
            }
        }

        private  List<CalibrationProportionShiftingView> listOfCalibrationProportionShifting { get; set; }
        public List<CalibrationProportionShiftingView> ListOfCalibrationProportionShifting
        {
            get => listOfCalibrationProportionShifting;
            set
            {
                if(listOfCalibrationProportionShifting != value)
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
                    if(selectedListOfMeasures != null)
                    {
                        selectedListOfMeasures.Save = true;
                    }
                    OnPropertyChanged(nameof(SelectedListOfMeasures));
                }
            }
        }
        private CalibrationAbsoluteShifting selectedListOfCalibrationAbsoluteShifting { get; set; }

        public CalibrationAbsoluteShifting  SelectedListOfCalibrationAbsoluteShifting
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
                    if(selectedListOfCalibrationProportionShifting != null)
                    {
                        selectedListOfCalibrationProportionShifting.Edit = true;
                    }
                    OnPropertyChanged(nameof(SelectedListOfCalibrationProportionShifting));
                }
            }
        }
        private CalibrationFE cfe = new CalibrationFE();
        private PercentageFE pct = new PercentageFE();

        public double NumberAp { get; set; }
        public double NumberBp { get; set; }
        public double NewMeasureLAB { get; set; }

        public double NewMeasureGE { get; set; }

        public double NewMeasureW { get; set; }

        public double NewMeasureB { get; set; }



      

     

        public double Shifting_P { get; set; }

        public double Ps { get; set; }

        public double Qs { get; set; }

      
        private double sum_1 { get; set; }
        public double Sum_1
        {
            get => sum_1;
            set
            {
                if(sum_1 != value)
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
        private double result_NewA { get; set; }
        public double Result_NewA
        {
            get => result_NewA;
            set
            {
                if (result_NewA != value)
                {
                    result_NewA = value;
                    OnPropertyChanged(nameof(Result_NewA));
                }
            }
        }
        private double result_NewB { get; set; }
        public double Result_NewB
        {
            get => result_NewB;
            set
            {
                if (result_NewB!= value)
                {
                    result_NewB = value;
                    OnPropertyChanged(nameof(Result_NewB));
                }
            }
        }
        private double result_NewP1 { get; set; }
        public double Result_NewP1
        {
            get => result_NewP1;
            set
            {
                if (result_NewP1 != value)
                {
                    result_NewP1 = value;
                    OnPropertyChanged(nameof(Result_NewP1));
                }
            }
        }
        private double result_NewQ1 { get; set; }
        public double Result_NewQ1
        {
            get => result_NewQ1;
            set
            {
                if (result_NewQ1 != value)
                {
                    result_NewQ1 = value;
                    OnPropertyChanged(nameof(Result_NewQ1));
                }
            }
        }
        private double result_NewR1 { get; set; }
        public double Result_NewR1
        {
            get => result_NewR1;
            set
            {
                if (result_NewR1 != value)
                {
                    result_NewR1 = value;
                    OnPropertyChanged(nameof(Result_NewR1));
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
        private double result_AbsoluteA { get; set; }
        public double Result_AbsoluteA
        {
            get => result_AbsoluteA;
            set
            {
                if (result_AbsoluteA != value)
                {
                    result_AbsoluteA = value;
                    OnPropertyChanged(nameof(Result_AbsoluteA));
                }
            }
        }
        private double result_AbsoluteB { get; set; }
        public double Result_AbsoluteB
        {
            get => result_AbsoluteB;
            set
            {
                if (result_AbsoluteB != value)
                {
                    result_AbsoluteB = value;
                    OnPropertyChanged(nameof(Result_AbsoluteB));
                }
            }
        }
        private double result_ProportionA { get; set; }
        public double Result_ProportionA
        {
            get => result_ProportionA;
            set
            {
                if (result_ProportionA != value)
                {
                    result_ProportionA = value;
                    OnPropertyChanged(nameof(Result_ProportionA));
                }
            }
        }
        private double result_ProportionB { get; set; }
        public double Result_ProportionB
        {
            get => result_ProportionB;
            set
            {
                if (result_ProportionB != value)
                {
                    result_ProportionB = value;
                    OnPropertyChanged(nameof(Result_ProportionB));
                }
            }
        }
        private NewCalibrationView selectedNewCalibration;
        public NewCalibrationView SelectedNewCalibration
        {
            get => selectedNewCalibration;
            set
            {
                if(selectedNewCalibration != value)
                {
                    selectedNewCalibration = value;
                   
                    OnPropertyChanged(nameof(SelectedNewCalibration));
                }
            }
        }
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
            try
            {
                db = new Model1();
                mfe = new MeasuresFE(db);
                ListOfMeasures = new List<MeasuresView>();
                ListOfMeasures.Clear();
                ListOfMeasures = mfe.GetMeasures();
                
                if (ListOfMeasures.Count > 0)
                {
                    cfe = new CalibrationFE(db);
                    pct = new PercentageFE(db);

                    ListOfCalibrations = new List<NewCalibrationView>();
                    ListOfCalibrations.Clear();
                    ListOfCalibrations = cfe.calibrationViews();

                    ListOfPercetange = new List<Percentage>();
                    ListOfPercetange.Clear();
                    ListOfPercetange = pct.GetPercentages().ToList();
                    
                    ListOfCalibrationAbsoluteShifting = new List<CalibrationAbsoluteShifting>();
                    ListOfCalibrationAbsoluteShifting.Clear();
                    ListOfCalibrationAbsoluteShifting = cfe.GetCalibrationsTwo().ToList();

                    ListOfCalibrationProportionShifting = new List<CalibrationProportionShiftingView>();
                    ListOfCalibrationProportionShifting.Clear();
                    ListOfCalibrationProportionShifting = cfe.GetCalibrationOnes();

                    ListOfValueOfProportion = new List<ValueOfProportion>();
                    ListOfValueOfProportion.Clear();
                    ListOfValueOfProportion = cfe.GetCalibrationsThree().ToList();
                  

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
                    if (ListOfCalibrations.Count > -1)
                    {
                        var suma = ListOfCalibrations[0].NumberA;
                        Result_NewA = suma * Result_P;
                        var sumb = ListOfCalibrations[0].NumberB;
                        Result_NewB = Result_P * sumb + Result_Q;
                    }
                    if (ListOfCalibrationAbsoluteShifting.Count > -1)
                    {
                        Result_AbsoluteA = ListOfCalibrationAbsoluteShifting[0].NumberATwo;
                        var bprocenat = ListOfCalibrationAbsoluteShifting[0].NumberBTwo;
                        var pomeraj = ListOfPercetange[0].NumberP;
                        Shifting_P = pomeraj;
                        var ukupno = -bprocenat + pomeraj;
                        var pozitivno = -1 * ukupno;
                        Result_AbsoluteB = pozitivno;
                    }
                    if (ListOfValueOfProportion.Count > -1 && ListOfCalibrationProportionShifting.Count > 1)
                    {
                        var a = ListOfValueOfProportion[0].NumberAThree;
                        var agore = ListOfCalibrationProportionShifting[1].L - ListOfCalibrationProportionShifting[0].L;
                        var adole = ListOfCalibrationProportionShifting[1].P - ListOfCalibrationProportionShifting[0].P;
                        var deljenje = (agore) / (adole);
                        Result_ProportionA = a * deljenje;
                        var bgore = ListOfCalibrationProportionShifting[0].P + ListOfValueOfProportion[0].NumberBThree;
                        var deljenjeb = bgore / a;
                        var l1 = ListOfCalibrationProportionShifting[0].L;
                        Result_ProportionB = Result_ProportionA * deljenjeb - l1;
                        Ps = ListOfCalibrationProportionShifting[0].SumLP;
                        Qs = ListOfCalibrationProportionShifting[1].SumLP;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Greška u podacima");
            }
        }
        public ICommand SaveChangesCommand => new RelayCommand(SaveChanges);
        private void SaveChanges()
        {
            db.SaveChanges();
            Load();
        }
        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            AddMeasures add = new AddMeasures();
            add.ShowDialog();
            var res = add.res;

            if (res != null)
            {
                db.Measures.Add(res);
                db.SaveChanges();
            }
            Load();
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
            else
            {
                MessageBox.Show("Makismalan broj clanova");
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
            else
            {
                MessageBox.Show("Maksimalan broj članova");
            }
            
        }
        public ICommand DelMeasureCommand => new RelayCommand(DelMeasure);
        private void DelMeasure()
        {
            if (MessageBox.Show("Da li ste sigurni?", "Eneleks 1.0", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

            }
            else
            {
                List<long> ids = new List<long>();

                foreach (var x in ListOfMeasures.Where(x=> x.IsSelected))
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
                        MessageBox.Show("Greska u podacima");
                    }
                    ListOfMeasures.Remove(ListOfMeasures.FirstOrDefault(x => x.ID == id));
                }
                Load();
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
              Load();
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

                dtMeasure.Columns.Add(new DataColumn("Broj uzorka [n]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo x [GE]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo y [LAB]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Vlaga [W]", typeof(string)));

                foreach (var z in ListOfMeasures)
                {
                    if (z.GetType() != typeof(MeasuresView)) continue;
                    MeasuresView x = (MeasuresView)z;
                    DataRow dr = dtMeasure.NewRow();

                    dr[0] = x.IdSort;
                    dr[1] = x.Ge;
                    dr[2] = x.Lab;
                    dr[3] = x.W;

                    dtMeasure.Rows.Add(dr);

                }

            }
            var listaSh2 = new Dictionary<DataTable, string>();

            listaSh2.Add(dtMeasure, "Eneleks kalibracija");

            Tools.SaveExcelFile(listaSh2);

        }
        public ICommand GetRowIndexMeasure => new RelayCommand<DataGridRowEventArgs>(RowIndexMeasure);
        private void RowIndexMeasure(DataGridRowEventArgs e)
        {
            if (ListOfMeasures.Count > 0)
            {

                var x = e.Row.DataContext as MeasuresView;
                if(x != null)
                {
                    var id = e.Row.GetIndex();
                    x.IdSort = id + 1;
                }
                

            }

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
                Load();
                NewMeasureGE = 0;
                NewMeasureLAB = 0;
                NewMeasureW = 0;
            }
            else
            {
                MessageBox.Show("Morate uneti podatke");
            }
        }

        private void DgOne_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var x = e.Row.DataContext as CalibrationProportionShiftingView;
            x.ID = (e.Row.GetIndex()) + 1;


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
         
            if (SelectedNewCalibration != null)
            {
                ListOfCalibrationEdit(SelectedNewCalibration, true);
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
                    MessageBox.Show("Greska u podacima");
                }
                ListOfCalibrationProportionShifting.Remove(ListOfCalibrationProportionShifting.FirstOrDefault(y => y.Id == SelectedListOfCalibrationProportionShifting.Id));
                Load();
            }
        }
        public double NumberPr { get; set; }
        public ICommand DelPercentangeCommand => new RelayCommand(DelPercentange);
        private void DelPercentange()
        {

            var listdel = new List<Percentage>();
            foreach (var x in ListOfPercetange)
            {
                listdel.Add((Percentage)x);
                db.Percentages.RemoveRange(listdel);
                db.SaveChanges();
            }
            Load();
           

        }
        public double NumberAa { get; set; }
        public double NumberBa { get; set; }
        public ICommand DelAbsoluteCommand => new RelayCommand(DelAbsolute);
        private void DelAbsolute()
        {
            if (ListOfCalibrationAbsoluteShifting.Count <= 0)
            {
                var listDel = new List<CalibrationAbsoluteShifting>();
                foreach (var x in ListOfCalibrationAbsoluteShifting)
                {
                    listDel.Add((CalibrationAbsoluteShifting)x);
                    db.CalibrationAbsoluteShiftings.RemoveRange(listDel);
                    db.SaveChanges();
                }
                Load();
            }
            else
            {
                MessageBox.Show("maksimalan broj clanova");
            }
        }
        public double NumberAs { get; set; }
        public double NumberBs { get; set; }

        public ICommand Graph1Command => new RelayCommand(Graph1);
        private void Graph1()
        {
            Graph1 gr = new Graph1(ListOfMeasures, Result_P, Result_Q);
            gr.ShowDialog();

        }
        public ICommand Graph2Command => new RelayCommand(Graph2);
        private void Graph2()
        {
            Graph1 gr = new Graph1(ListOfMeasures, Result_P, Result_Q, Shifting_P);
            gr.ShowDialog();
        }
        public ICommand Graph3Command => new RelayCommand(Graph3);
        private void Graph3()
        {
            Graph1 gr = new Graph1(ListOfMeasures, Result_P, Result_Q, Ps, Qs, Shifting_P);
            gr.ShowDialog();
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Windows.AddMeasures add = new Windows.AddMeasures();
            add.ShowDialog();
        }
        public ICommand SaveMeasureCommand => new RelayCommand(SaveMeasure);
        private void SaveMeasure()
        {
            SaveTransWin save = new SaveTransWin(ListOfMeasures);
            save.ShowDialog();
        }
        public ICommand SaveWinCommand => new RelayCommand(SaveWin);
        private void SaveWin()
        {
            SaveCalibrationWindow save = new SaveCalibrationWindow(Load);
            save.ShowDialog();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
