using enelex3.FrontEndMethods;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace enelex3.UserControls
{
    /// <summary>
    /// Interaction logic for ScatterLineGraph.xaml
    /// </summary>
    public partial class ScatterLineGraph : UserControl
    {     
        public object Mapper { get; set; }   
        
        public ScatterLineGraph()
        {
            InitializeComponent();
        }

        public void SetMeasureViewToGraph(List<MeasuresView> input, double p, double q)
        {            
            DataContext = this;  
            ValuesA.Clear();
            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));
                }
            }
            ValuesB.Clear();
            if (ValuesA.Count > 1)
            {
                var prva = ValuesA.First();
                var poslednja = ValuesA.Last();
                ValuesB.Add(new ObservablePoint(prva.X, p * prva.X - q));
                ValuesB.Add(new ObservablePoint(poslednja.X, p * poslednja.X - q));
            }
        }

        public ChartValues<ObservablePoint> ValuesA { get; set; } = new ChartValues<ObservablePoint>();
        public ChartValues<ObservablePoint> ValuesB { get; set; } = new ChartValues<ObservablePoint>();
        public ChartValues<ObservablePoint> ValuesC { get; set; } = new ChartValues<ObservablePoint>();


    }
}
