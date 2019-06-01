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

namespace enelex3
{
    /// <summary>
    /// Interaction logic for Graph3.xaml
    /// </summary>
    public partial class Graph3 : Window
    {
        
        public Graph3(List<MeasuresView> input, double p, double q, double Ps, double Qs)
        {
            InitializeComponent();
            Grafik3.SetMeasureViewToGraph3(input, p, q, Ps, Qs);
        }
    }
}
