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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using enelex3.FrontEndMethods;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for Graph1.xaml
    /// </summary>
    public partial class Graph1 : Window
    {
        Model1 db = new Model1();
        private MeasuresFE mfe;

        
        public object Mapper { get; set; }
        public Graph1()
        {
            InitializeComponent();
            
            
            ValuesA = new ChartValues<ObservablePoint>();
            ValuesB = new ChartValues<ObservablePoint>();
            ValuesC = new ChartValues<ObservablePoint>();
            mfe = new MeasuresFE(db);
            var ListOfMeasures = mfe.GetMeasures();

            if (ListOfMeasures.Count > 0)
            {
            
                for ( var i = 0 ; i < ListOfMeasures.Count; i++)
                {
                    ValuesA.Add(new ObservablePoint(ListOfMeasures[i].Ge, ListOfMeasures[i].Lab));                 
                }
            }
          

            DataContext = this;
        }
      
        public ChartValues<ObservablePoint> ValuesA { get; set; }
        public ChartValues<ObservablePoint> ValuesB { get; set; }
        public ChartValues<ObservablePoint> ValuesC { get; set; }

        
    }
}

    











        

       

        
    

