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
using enelex3.View;
using enelex3.ViewModel;

namespace enelex3.Windows
{
    /// <summary>
    /// Interaction logic for SaveTransWin.xaml
    /// </summary>
    public partial class SaveTransWin : Window
    {
        public SaveTransWin(List<MeasuresView> listOfMeasures)
        {
            DataContext = new SaveTransViewModel(listOfMeasures);
            InitializeComponent();
        }
    }
}
