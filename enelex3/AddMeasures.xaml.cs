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
    /// Interaction logic for AddMeasures.xaml
    /// </summary>
    public partial class AddMeasures : Window
    {
        private Model1 db = new Model1();
        public Measures res = new Measures();
        bool Save = false;
        public AddMeasures()
        {
            InitializeComponent();
            DataContext = res;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Save) res = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save = true;
            Close();
        }
    }
}
