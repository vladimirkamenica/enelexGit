using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace enelex3.Converters
{
    class ConverterWidthDataGrid : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int actualWidth = 0;

            foreach (var item in values)
            {
                actualWidth += System.Convert.ToInt32(item);
            }

            return actualWidth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var x = DependencyProperty.UnsetValue;
            var y = DependencyProperty.UnsetValue;
            return new object[] { x, y };
        }
    }
}
