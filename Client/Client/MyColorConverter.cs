using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Client
{
    class MyColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {               

                // Если ЗП сотрудника < 20000, то окрась в красный цвет
                if ((decimal)value < 20000)
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            catch (Exception)
            {

            }


            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
            //return DependencyProperty.UnsetValue;
        }
    }
}
