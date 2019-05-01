using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using enelex3.FrontEndMethods;
using ClosedXML.Excel;
using System.Data;
using Microsoft.Win32;
using enelex3.Alati;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1 db = new Model1();
        public MainWindow()
        {
            InitializeComponent();
            ListOfMeasures = new List<MeasuresView>();
            ListOfCalibrations = new List<Calibration>();
            ListOfCalibarationsThree = new List<CalibrationThree>();
            ListOfPercetange = new List<Percentage>();
            ListOfCalibrationTwo = new List<CalibrationTwo>();
            ListOfCalibrationOne = new List<CalibrationOneView>();
            DataContext = this;
           

        }
        private MeasuresFE mfe;
        public List<MeasuresView> ListOfMeasures { get; set; }
        public List<Calibration> ListOfCalibrations { get; set; }
        public List<CalibrationThree> ListOfCalibarationsThree { get; set; }
        public List<Percentage> ListOfPercetange { get; set; }
        public List<CalibrationTwo> ListOfCalibrationTwo { get; set; }
        public List<CalibrationOneView>  ListOfCalibrationOne { get; set; }
        private CalibrationFE cfe;
        private PercentageFE pct;

        public double FinalA { get; set; }
        
        public double FinalB { get; set; }

        private void Load()
        {
            db = new Model1();
            mfe = new MeasuresFE(db);
            
            ListOfMeasures.Clear();
            ListOfMeasures.AddRange(mfe.GetMeasures());
           


            if (ListOfMeasures.Count > 0)
            {

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
               
                      
                if (ListOfCalibarationsThree.Count > -1)
                {
                    ListOfCalibarationsThree.Clear();
                    ListOfCalibarationsThree.AddRange(cfe.GetCalibrationsThree());
                }

                
                var maxId = ListOfMeasures.Max(x => x.IdSort);
                tbn.Text = maxId.ToString();
                tbn1.Text = maxId.ToString();

               


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

                var sumP = gorep / dolep;
                tbP.Text = sumP.ToString("0.####");
               
                var sumQ1 = ListOfMeasures.Sum(x => x.Lab);
                tbSumQ1.Text = sumQ1.ToString();

                var sumQ2 = ListOfMeasures.Sum(x => x.Ge);


                var sumq2 = sumQ2 * sumP;
                tbSumQ2.Text = sumq2.ToString("0.####");
                var goreq = sumQ1 - sumq2;



                var sumQ = goreq / maxId;
                tbQ.Text = sumQ.ToString("0.#####");

                if (ListOfCalibrations.Count > 0)
                {
                    var suma = ListOfCalibrations[0].NumberA;
                    var sumaa = suma * sumP;
                    tbA.Text = sumaa.ToString("0.####");

                    var sumb = ListOfCalibrations[0].NumberB;
                    var sumbb = sumP * sumb + sumQ;
                    tbB.Text = sumbb.ToString("0.####");

                    var aprocenat = ListOfCalibrationTwo[0].NumberATwo;
                    tbAprocenat.Text = aprocenat.ToString();

                    var bprocenat = ListOfCalibrationTwo[0].NumberBTwo;
                    var pomeraj = ListOfPercetange[0].NumberP;
                    var ukupno = -bprocenat + pomeraj;
                    var pozitivno = -1 * ukupno;
                    tbBprocenat.Text = pozitivno.ToString();


                }
                

                if (ListOfCalibarationsThree.Count > 0  && ListOfCalibrationOne.Count > 1)
                {
                    var a = ListOfCalibarationsThree[0].NumberAThree;
                    var agore = ListOfCalibrationOne[1].L - ListOfCalibrationOne[0].L;
                    var adole = ListOfCalibrationOne[1].P - ListOfCalibrationOne[0].P;
                    var deljenje = agore / adole;
                    FinalA = a * deljenje;                   
                    tbAsraz.Text = FinalA.ToString();

                    var bgore = ListOfCalibrationOne[0].P + ListOfCalibarationsThree[0].NumberBThree;
                    var deljenjeb = bgore / a;
                    var l1 = ListOfCalibrationOne[0].L;
                    FinalB = FinalA * deljenjeb - l1;
                    tbBsraz.Text = FinalB.ToString("0.####");

                    
                }

              
            }
            dgMeasures.Items.Refresh();
            dgTipAB.Items.Refresh();
            dgTipAB3.Items.Refresh();
            dgTipAB2.Items.Refresh();
            dgApsolutno.Items.Refresh();
            dgOne.Items.Refresh();
            UpdateLayout();
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

       


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            Load();
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
        private Measures copylist(MeasuresView input)
        {
            Measures list = new Measures
            {
                Id = input.Id,
                Ge = input.Ge,
                Lab = input.Lab,

            };
            return list;
        }


        //azuriraj
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selektovano = dgMeasures.SelectedItem as MeasuresView;
            if (selektovano != null)
            {
                var id = selektovano.IdSort;
                var izbaze = db.Measures.Find(id);
                db.SaveChanges();
            }
        }

        //obrisi
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //dg....selecteditem == measureview
            //var id = measureview.id;
            //var izbaze = db.measures.find(id);
            //db.measures.remove(izbaze); 
            //stavis u try db.measures.savechanges();
            // listofmeasasdas.remove (selectovani);
            //dg.items.update();

          var selektovano =  dgMeasures.SelectedItem as MeasuresView;
            if (selektovano != null)
            {
                var id = selektovano.Id;
                var izbaze = db.Measures.Find(id);
                db.Measures.Remove(izbaze);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("gfhg");
                }
                ListOfMeasures.Remove(selektovano);

                Load();
            }
        }

        private void dgMeasures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var listofone = cfe.GetCalibrationOnes();
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
                listofone.Remove(selektovano);

                Load();

            }
        }

        private void Excel_Button(object sender, RoutedEventArgs e)
        {
            Load();
            DataTable dtMeasure = new DataTable();
        
            if (dgMeasures.Items.Count > 0)
            {
                
                dtMeasure.Columns.Add(new DataColumn("Broj uzorka [n]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo [GE]", typeof(string)));
                dtMeasure.Columns.Add(new DataColumn("Pepeo [LAB]", typeof(string)));
               
                foreach (var z in dgMeasures.Items)
                {
                    if (z.GetType() != typeof(MeasuresView)) continue;
                    MeasuresView x = (MeasuresView)z;
                    DataRow dr = dtMeasure.NewRow();
                   
                    dr[0] = x.IdSort;
                    dr[1] = x.Ge;
                    dr[2] = x.Lab;
                   
                    dtMeasure.Rows.Add(dr);
                    
                }

            }
            var listaSh2 = new Dictionary<DataTable, string>();
            
            listaSh2.Add(dtMeasure, "Eneleks kalibracija");

            Tools.SaveExcelFile(listaSh2);

        }

       
    }
}
