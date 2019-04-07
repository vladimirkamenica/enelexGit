using System;
using System.Collections.Generic;
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
            DataContext = this;

        }
        private MeasuresFE mfe;
        public List<MeasuresView> ListOfMeasures { get; set; }
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
               var listOfCalibrations = cfe.GetCalibrations();
                var listOfCalibarationsThree = cfe.GetCalibrationsThree();
                dgTipAB.ItemsSource = listOfCalibrations;
                dgApsolutno.ItemsSource = pct.GetPercentages();
                dgTipAB2.ItemsSource = cfe.GetCalibrationsTwo();
                dgOne.ItemsSource = cfe.GetCalibrationOnes();

                
                if (dgTipAB3.Items.Count > -1)
                {
                    dgTipAB3.ItemsSource = listOfCalibarationsThree;
                }

               
                var maxId = ListOfMeasures.Max(x => x.Id);
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

                var suma = listOfCalibrations.Sum(x => x.NumberA);
                var sumaa = suma * sumP;
                tbA.Text = sumaa.ToString("0.####");

                var sumb = listOfCalibrations.Sum(x => x.NumberB);
                var sumbb = sumP * sumb + sumQ;
                tbB.Text = sumbb.ToString("0.####");

                var aprocenat = cfe.GetCalibrationsTwo().Sum(x => x.NumberATwo);
                tbAprocenat.Text = aprocenat.ToString();

                var bprocenat = cfe.GetCalibrationsTwo().Sum(x => x.NumberBTwo);
                var pomeraj = pct.GetPercentages().Sum(x => x.NumberP);
                var ukupno = -bprocenat + pomeraj;
                var pozitivno = -1 * ukupno;
                tbBprocenat.Text = pozitivno.ToString();
                if(listOfCalibarationsThree.Count > 0)
                {
                    var a = listOfCalibarationsThree.Max(x => x.NumberAThree);
                    var agore = cfe.GetCalibrationOnes().Max(x => x.L) - cfe.GetCalibrationOnes().Min(x => x.L);
                    var adole = cfe.GetCalibrationOnes().Max(x => x.P) - cfe.GetCalibrationOnes().Min(x => x.P);
                    var deljenje = agore / adole;
                    FinalA = a * deljenje;
                    tbAsraz.Text = FinalA.ToString("0.####");

                    var bgore = cfe.GetCalibrationOnes().Min(x => x.P) + listOfCalibarationsThree.Max(x => x.NumberBThree);
                    var deljenjeb = bgore / a;
                    var l1 = cfe.GetCalibrationOnes().Min(x => x.L);
                    FinalB = FinalA * deljenjeb - l1;
                    tbBsraz.Text = FinalB.ToString("0.####");
                }

              
            }
            dgMeasures.Items.Refresh();
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
            AddCalibrationOne ack = new AddCalibrationOne();
            ack.ShowDialog();
            var resOne = ack.resOne;

            if (resOne != null)
            {
                db.CalibratonOnes.Add(resOne);
                db.SaveChanges();
            }
            Load();
        }

        //azuriraj
        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
        }
    }
}
