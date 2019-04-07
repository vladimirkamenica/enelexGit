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
            DataContext = this;

        }
        private MeasuresFE mfe;
        private List<MeasuresView> table;
        private CalibrationFE cfe;
        private PercentageFE pct;

        private void Load()
        {
            db = new Model1();
            mfe = new MeasuresFE(db);
            table = mfe.GetMeasures();
            dgMeasures.ItemsSource = table;

            if (table.Count > 0)
            {

                db = new Model1();


             
               
                cfe = new CalibrationFE(db);
                pct = new PercentageFE(db);
               
                dgTipAB.ItemsSource = cfe.GetCalibrations();
                dgApsolutno.ItemsSource = pct.GetPercentages();
                dgTipAB2.ItemsSource = cfe.GetCalibrationsTwo();
                dgOne.ItemsSource = cfe.GetCalibrationOnes();

                
                if (dgTipAB3.Items.Count > -1)
                {
                    dgTipAB3.ItemsSource = cfe.GetCalibrationsThree();
                }

               
                var maxId = table.Max(x => x.Id);
                tbn.Text = maxId.ToString();
                tbn1.Text = maxId.ToString();


                var sum2 = table.Sum(x => x.Ge);
                tbSum2.Text = sum2.ToString();

                var sum3 = table.Sum(x => x.Lab);
                tbSum3.Text = sum3.ToString();

                var sum1 = maxId * table.Sum(x => x.SumMeasure);
                tbSum1.Text = sum1.ToString();

                var sum4 = table.Sum(x => x.SumGe) * maxId;
                tbSum4.Text = sum4.ToString();

                var sum5 = table.Sum(x => x.Ge) * table.Sum(x => x.Ge);
                tbSum5.Text = sum5.ToString();

                var gorep = sum1 - sum2 * sum3;
                var dolep = sum4 - sum5;

                var sumP = gorep / dolep;
                tbP.Text = sumP.ToString("0.####");

                var sumQ1 = table.Sum(x => x.Lab);
                tbSumQ1.Text = sumQ1.ToString();

                var sumQ2 = table.Sum(x => x.Ge);


                var sumq2 = sumQ2 * sumP;
                tbSumQ2.Text = sumq2.ToString("0.####");
                var goreq = sumQ1 - sumq2;



                var sumQ = goreq / maxId;
                tbQ.Text = sumQ.ToString("0.#####");

                var suma = cfe.GetCalibrations().Sum(x => x.NumberA);
                var sumaa = suma * sumP;
                tbA.Text = sumaa.ToString("0.####");

                var sumb = cfe.GetCalibrations().Sum(x => x.NumberB);
                var sumbb = sumP * sumb + sumQ;
                tbB.Text = sumbb.ToString("0.####");

                var aprocenat = cfe.GetCalibrationsTwo().Sum(x => x.NumberATwo);
                tbAprocenat.Text = aprocenat.ToString();

                var bprocenat = cfe.GetCalibrationsTwo().Sum(x => x.NumberBTwo);
                var pomeraj = pct.GetPercentages().Sum(x => x.NumberP);
                var ukupno = -bprocenat + pomeraj;
                var pozitivno = -1 * ukupno;
                tbBprocenat.Text = pozitivno.ToString();

                var a = cfe.GetCalibrationsThree().Max(x => x.NumberAThree);
                var agore = cfe.GetCalibrationOnes().Max(x => x.L) - cfe.GetCalibrationOnes().Min(x => x.L);
                var adole = cfe.GetCalibrationOnes().Max(x => x.P) - cfe.GetCalibrationOnes().Min(x => x.P);
                var deljenje = agore / adole;
                var konacno = a * deljenje;
                tbAsraz.Text = konacno.ToString("0.####");

                var bgore = cfe.GetCalibrationOnes().Min(x => x.P) + cfe.GetCalibrationsThree().Max(x => x.NumberBThree);
                var deljenjeb = bgore / a;
                var l1 = cfe.GetCalibrationOnes().Min(x => x.L);
                var konacnob = konacno * deljenjeb - l1;
                tbBsraz.Text = konacnob.ToString("0.####");
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
    }
}
