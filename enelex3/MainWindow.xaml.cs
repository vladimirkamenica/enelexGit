using ClosedXML.Excel;
using enelex3.Alati;
using enelex3.FrontEndMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1 db = new Model1();
        public double FinalA { get; set; }
        public double FinalB { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListOfMeasures = new List<MeasuresView>();
            //ListOfMeasures = new ObservableCollection<MeasuresView>();
            ListOfCalibrations = new List<Calibration>();
            ListOfCalibarationsThree = new List<CalibrationThree>();
            ListOfPercetange = new List<Percentage>();
            ListOfCalibrationTwo = new List<CalibrationTwo>();
            ListOfCalibrationOne = new List<CalibrationOneView>();
            SumP = 0;
            SumQ = 0;
            NewMeasureB = 0;
            DataContext = this;
          
        }
        private MeasuresFE mfe;
      // public ObservableCollection<MeasuresView> ListOfMeasures { get; set; }
        public List<MeasuresView> ListOfMeasures { get; set; }
        public List<Calibration> ListOfCalibrations { get; set; }
        public List<CalibrationThree> ListOfCalibarationsThree { get; set; }
        public List<Percentage> ListOfPercetange { get; set; }
        public List<CalibrationTwo> ListOfCalibrationTwo { get; set; }
        public List<CalibrationOneView> ListOfCalibrationOne { get; set; }
        private CalibrationFE cfe;
        private PercentageFE pct;


        public double NewMeasureLAB { get; set; }

        public double NewMeasureGE { get; set; }

        public double NewMeasureW { get; set; }

        public double NewMeasureB { get; set; }

       

        public double SumQ { get; set; }

        public double SumP { get; set; }

        public double NumP { get; set; }

        public double Ps { get; set; }

        public double Qs { get; set; }

        public double PrintP { get; set; }

        public double PrintQ { get; set; }

        public double PrintA { get; set; }

        public double PrintB { get; set; }

        public double PrintA1 { get; set; }

        public double PrintB1 { get; set; }

        public double PrintAa1 { get; set; }

        public double PrintBa1 { get; set; }

        public double PrintBa { get; set; }

        public int CountOne { get; set; }

        public double PrintAs { get; set; }

        public double PrintBs { get; set; }

        public double PrintAs1 { get; set; }

        public double PrintBs1 { get; set; }


        public double PrintW { get; set; }


        public double PrintAPr { get; set; }

        private void Load()
        {          

            try
            {
                db = new Model1();

                mfe = new MeasuresFE(db);

               ListOfMeasures.Clear();
               ListOfMeasures.AddRange(mfe.GetMeasures());
              
               // foreach (var i in mfe.GetMeasures()) ListOfMeasures.Add(i);

                // var ListOfMeasures = mfe.GetMeasures();
                //  dgMeasures.ItemsSource = ListOfMeasures;

                if (ListOfMeasures.Count > 0)
                {
                    Measure mes = new Measure();
                    
                    db = new Model1();
                    cfe = new CalibrationFE(db);
                    pct = new PercentageFE(db);

                    ListOfCalibrations.Clear();
                    ListOfCalibrations.AddRange(cfe.GetCalibrations());
                    ListOfPercetange.Clear();
                    ListOfPercetange.AddRange(pct.GetPercentages());
                    ListOfCalibrationTwo.Clear();
                    ListOfCalibrationTwo.AddRange(cfe.GetCalibrationsTwo());
                    ListOfCalibrationOne.Clear();
                    ListOfCalibrationOne.AddRange(cfe.GetCalibrationOnes());
                 
                    //  var ListOfCalibrations = cfe.GetCalibrations();
                    // dgTipAB.ItemsSource = ListOfCalibrations;

                    if (ListOfCalibarationsThree.Count > -1)
                    {
                        ListOfCalibarationsThree.Clear();
                        ListOfCalibarationsThree.AddRange(cfe.GetCalibrationsThree());
                    }

                    var maxId = ListOfMeasures.Count;
                    NewMeasureB = maxId + 1;
                    tbBr.Text = NewMeasureB.ToString();
                    tbn.Text = maxId.ToString();
                    tbn1.Text = maxId.ToString();


                    var vlaga = ListOfMeasures.Sum(x => x.W) / maxId;
                    tbV.Text = vlaga.ToString("N4");
                    tbV1.Text = vlaga.ToString("N4");
                    tbV2.Text = vlaga.ToString("N4");
                    PrintW = vlaga;

                    var sum2 = ListOfMeasures.Sum(x => x.Ge);
                    tbSum2.Text = sum2.ToString();

                    var sum3 = ListOfMeasures.Sum(x => x.Lab);
                    tbSum3.Text = sum3.ToString();

                  

                    var sum1 = maxId * ListOfMeasures.Sum(x => x.SumMeasure);
                    tbSum1.Text = sum1.ToString();

                    var sum4 = ListOfMeasures.Sum(x => x.SumGe) * maxId;
                    tbSum4.Text = sum4.ToString();

                    var sum5 = ListOfMeasures.Sum(x => x.Ge) * ListOfMeasures.Sum(x => x.Ge);
                    tbSum5.Text = sum5.ToString();

                    var gorep = sum1 - sum2 * sum3;
                    var dolep = sum4 - sum5;

                    SumP = gorep / dolep;
                    tbP.Text = SumP.ToString("N4");

                    PrintP = SumP;

                    var sumQ1 = ListOfMeasures.Sum(x => x.Lab);
                    tbSumQ1.Text = sumQ1.ToString();

                    var sumQ2 = ListOfMeasures.Sum(x => x.Ge);


                    var sumq2 = sumQ2 * SumP;
                    tbSumQ2.Text = sumq2.ToString("0.####");
                    var goreq = sumQ1 - sumq2;
                    SumQ = goreq / maxId;
                    tbQ.Text = SumQ.ToString("N4");

                    PrintQ = SumQ;

                    if (ListOfCalibrations.Count > 0)
                    {
                        var suma = ListOfCalibrations[0].NumberA;
                        var sumaa = suma * SumP;
                        tbA.Text = sumaa.ToString("0.####");
                        PrintA = sumaa;
                        PrintA1 = suma;
                        var sumb = ListOfCalibrations[0].NumberB;
                        var sumbb = SumP * sumb + SumQ;
                        tbB.Text = sumbb.ToString("0.####");
                        PrintB = sumbb;
                        PrintB1 = sumb;
                    }
                    if (ListOfCalibrationTwo.Count > 0)
                    {
                        var aprocenat = ListOfCalibrationTwo[0].NumberATwo;
                        tbAprocenat.Text = aprocenat.ToString("0.##");
                        PrintAa1 = aprocenat;

                        var bprocenat = ListOfCalibrationTwo[0].NumberBTwo;
                        var pomeraj = ListOfPercetange[0].NumberP;
                        NumP = pomeraj;
                        PrintAPr = pomeraj;
                        PrintBa = bprocenat;

                        var ukupno = -bprocenat + pomeraj;
                        var pozitivno = -1 * ukupno;
                        tbBprocenat.Text = pozitivno.ToString("0.##");
                        PrintBa1 = pozitivno;
                    }


                    if (ListOfCalibarationsThree.Count > 0 && ListOfCalibrationOne.Count > 1)
                    {
                        var a = ListOfCalibarationsThree[0].NumberAThree;
                        var agore = ListOfCalibrationOne[1].L - ListOfCalibrationOne[0].L;
                        var adole = ListOfCalibrationOne[1].P - ListOfCalibrationOne[0].P;
                        var deljenje = agore / adole;
                        FinalA = a * deljenje;
                       tbAsraz.Text = FinalA.ToString("N4");

                        var bgore = ListOfCalibrationOne[0].P + ListOfCalibarationsThree[0].NumberBThree;
                        var deljenjeb = bgore / a;
                        var l1 = ListOfCalibrationOne[0].L;
                        FinalB = FinalA * deljenjeb - l1;
                        tbBsraz.Text = FinalB.ToString("N4");
                      

                        Ps = ListOfCalibrationOne[0].SumLP;
                        Qs = ListOfCalibrationOne[1].SumLP;
                        PrintAs = FinalA;
                        PrintBs = FinalB;
                        PrintAs1 = a;
                        PrintBs1 = ListOfCalibarationsThree[0].NumberBThree;

                    }

                    CountOne = ListOfCalibrationOne.Count;
                }
                dgMeasures.Items.Refresh();
                dgTipAB.Items.Refresh();
                dgTipAB3.Items.Refresh();
                dgTipAB2.Items.Refresh();
                dgApsolutno.Items.Refresh();
                dgOne.Items.Refresh();
                UpdateLayout();
           }
           catch
            {
              MessageBox.Show("Greška u podacima");
            }
           
          

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
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



        public double NumberAp { get; set; }
        public double NumberBp { get; set; }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfCalibrations.Count <= 0)
            {

                if (NumberAp > 0 && NumberBp > 0)
                {
                    var resP = new Calibration();
                    resP.NumberA = NumberAp;
                    resP.NumberB = NumberBp;
                    if (resP != null)
                    {

                        db.Calibrations.Add(resP);
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

        private void Add2_Click(object sender, RoutedEventArgs e)
        {

            if (dgOne.Items.Count <= 1)
            {
                AddCalibrationOne ack = new AddCalibrationOne();
                ack.ShowDialog();
                var resOne = ack.resOne;

                if (resOne != null)
                {
                    db.CalibratonOnes.Add(resOne);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Maksimalan broj članova");
            }
            Load();
        }
      


        //azuriraj
       

        //obrisi
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
           
      
            

            if (MessageBox.Show("Da li ste sigurni?", "Eneleks 1.0", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

            }
            else
            {
                List<long> ids = new List<long>();

                foreach (var x in dgMeasures.SelectedItems)
                {
                    var selektovano = x as MeasuresView;
                    if (selektovano != null)
                    {
                        var id = selektovano.ID;
                        ids.Add(id);

                    }

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
        private void dgMeasures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = dgMeasures.SelectedItem as MeasuresView;
            if (sel != null)
            {
                sel.Save = true;
            }           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selektovano = ListOfMeasures.Where(x => x.Save);
            if (selektovano != null)
            {
                foreach (var x in selektovano)
                    if (x != null)
                    {
                        {
                            CopyMeasureViewToBase(x, true);
                            x.Save = false;
                        }
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
        private void Del_One(object sender, RoutedEventArgs e)
        {
            var selektovano = dgOne.SelectedItem as CalibrationOneView;
            if (selektovano != null)
            {
                
                var id = selektovano.Id;
                var izbaze = db.CalibratonOnes.Find(id);
                db.CalibratonOnes.Remove(izbaze);
                try
                {
                 
                        db.SaveChanges();
                    
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("gfhg");
                }
                ListOfCalibrationOne.Remove(selektovano);

                Load();

            }
        }

        private void Excel_Button(object sender, RoutedEventArgs e)
        {
            Load();
          XLWorkbook eksel = new XLWorkbook();
          
            DataTable dtMeasure = new DataTable();
           
            if (dgMeasures.Items.Count > 0)
            {
               
                dtMeasure.Columns.Add(new DataColumn("Broj uzorka [n]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo x [GE]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo y [LAB]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Vlaga [W]", typeof(string)));

                foreach (var z in dgMeasures.Items)
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
       
        private void DgMeasures_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (ListOfMeasures.Count > 0)
            {
                
             var x = e.Row.DataContext as MeasuresView;              
              var id = e.Row.GetIndex();
               x.IdSort = id +1;
               
            }

        }
       
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (NewMeasureGE > 0 && NewMeasureLAB > 0 & NewMeasureW > 0 )
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
            }
            else
            {
                MessageBox.Show("Morate uneti podatke");
            }           
            NewMeasureGE = 0;
            NewMeasureLAB = 0;
            NewMeasureW = 0;
            tbGE.Text = "0,00";
            tbLAB.Text ="0,00";
            tbW.Text = "0,00";
            Load();
        }

        private void DgOne_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var x = e.Row.DataContext as CalibrationOneView;
            x.ID = (e.Row.GetIndex()) + 1;


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            Load();
        }

        private void CopyOneViewToBase(CalibrationOneView input, bool saveDB, Model1 db = null)
        {

            db = db ?? new Model1();
            var x = db.CalibratonOnes.Find(input.Id);
            x.Id = input.Id;
            x.L = input.L;
            x.P = input.P;           
            if (saveDB)
            {
                db.SaveChanges();
            }
            db.Dispose();

        }
        private void Update_One(object sender, RoutedEventArgs e)
        {
            var sel = dgOne.SelectedItem as CalibrationOneView;
            if(sel != null)
            {
                CopyOneViewToBase(sel, true);
            }
            Load();
        }
        public double NumberL { get; set; }
        public double NumberP { get; set; }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ListOfCalibrationOne.Count <= 1)
            {
                if (NumberL > 0 && NumberP > 0)
                {
                    var resO = new CalibratonOne();
                    resO.L = NumberL;
                    resO.P = NumberP;
                    if (resO != null)
                    {
                        db.CalibratonOnes.Add(resO);
                        db.SaveChanges();
                        Load();
                        
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("maksimalan broj clanova");
            }
        }
        public double NumberPr { get; set; }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (ListOfPercetange.Count <= 0)
            {

                if (NumberPr > 0 )
                {
                    var resPr = new Percentage();
                    resPr.NumberP = NumberPr;
                    
                    if (resPr != null)
                    {

                        db.Percentages.Add(resPr);
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
        public double NumberAa { get; set; }
        public double NumberBa { get; set; }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (ListOfCalibrationTwo.Count <= 0)
            {
                if (NumberAa > 0 && NumberBa > 0)
                {
                    var resA = new CalibrationTwo();
                    resA.NumberATwo = NumberAa;
                    resA.NumberBTwo = NumberBa;
                    if (resA != null)
                    {
                        db.CalibrationTwos.Add(resA);
                        db.SaveChanges();
                        Load();
                    }
                }
            }
            else
            {
                MessageBox.Show("maksimalan broj clanova");
            }
        }
        public double NumberAs { get; set; }
        public double NumberBs { get; set; }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (ListOfCalibarationsThree.Count <= 0)
            {
                if (NumberAs > 0 && NumberBs > 0)
                {
                    var resAs = new CalibrationThree();
                    resAs.NumberAThree = NumberAs;
                    resAs.NumberBThree = NumberBs;
                    if (resAs != null)
                    {
                        db.CalibrationThrees.Add(resAs);
                        db.SaveChanges();
                        Load();
                    }
                }
            }
            else
            {
                MessageBox.Show("maksimalan broj clanova");
            }
        }

        private void Graph1(object sender, RoutedEventArgs e)
        {
            Graph1 gr = new Graph1(ListOfMeasures, SumP, SumQ);
            gr.ShowDialog();               

        }

        private void Graph2(object sender, RoutedEventArgs e)
        {
            Graph1 gr = new Graph1(ListOfMeasures, SumP, SumQ, NumP);
            gr.ShowDialog();
        }    

        private void Graph3(object sender, RoutedEventArgs e)
        {
            Graph1 gr = new Graph1(ListOfMeasures, SumP, SumQ, Ps, Qs);
            gr.ShowDialog();
        }

        private void DgMeasures_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void DgMeasures_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.End )
            {
               
            }
        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void TbGE_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrintSheet printSheet = new PrintSheet(PrintP, PrintQ, PrintA, PrintAPr, PrintB, PrintW, PrintA1, PrintB1, PrintAa1, PrintBa1, PrintBa, CountOne, PrintAs, PrintAs1, PrintBs, PrintBs1);
            printSheet.ShowDialog();
        }

        private void TbBr_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            PrintSheet printSheet = new PrintSheet(PrintP, PrintQ, PrintA, PrintAPr, PrintB, PrintW, PrintA1, PrintB1, PrintAa1, PrintBa1, PrintBa, CountOne, PrintAs, PrintAs1, PrintBs, PrintBs1);
            printSheet.ShowDialog();
        }

        private void DgTipAB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbL_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbBsraz_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
