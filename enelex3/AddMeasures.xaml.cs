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
using System.Windows.Shapes;
using enelex3.FrontEndMethods;
using enelex3.Interfaces;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for AddMeasures.xaml
    /// </summary>
    public partial class AddMeasures : Window
    {
        private Model1 db = new Model1();
        public Measure res = new Measure();
        bool Save = false;
        
        public AddMeasures()
        {
            InitializeComponent();           
            DataContext = res;
            Test(new Measure());
            Index();

        }
       
        private MeasuresFE mfe;
        public double IndexId { get; set; }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Save) res = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save = true;
            Close();
        }
        
        private void Index()
        {
            db = new Model1();
            mfe = new MeasuresFE(db);
            MeasuresView mv = new MeasuresView();
            var ListOfMeasures = mfe.GetMeasures();

            if (ListOfMeasures.Count > -1)
            {          
                var broj = 1;
                IndexId = broj;
                tbIndex.Text = IndexId.ToString();               
            }
            if (ListOfMeasures.Count > 0)
            {
                IndexId = 0;  
                var index = ListOfMeasures.Max(x => x.ID);
                var index2 = index + 1;             
                IndexId = index2;
                tbIndex.Text = IndexId.ToString();
            }
            

        }

        private void Test (IBasicData input)
        {
            var a = input.ID;
            var db = new Model1();
            var x = db.Set (input.GetType());
            var b = "";
        }

    }
}
