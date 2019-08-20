using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace enelex3.Alati
{
    public class SaveToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //  if ((bool)value) return Brushes.DeepPink;
            // else return Brushes.Black;

            var defColor = Colors.White;            
            if (value != null)
            {
                 var o = (bool)value;
                 if (o) defColor = Colors.Red;
           }
           return defColor;
           
         
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
