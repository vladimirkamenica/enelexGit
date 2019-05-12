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
        public Graph1(List<MeasuresView> input, double p, double q)
        {
            InitializeComponent();
            Grafik.SetMeasureViewToGraph(input, p, q);          
        }       
    }
}

    











        

       

        
    

