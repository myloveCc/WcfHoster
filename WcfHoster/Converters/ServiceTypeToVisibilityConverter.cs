using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model;
using System.Windows;

namespace WcfHoster
{
    public class ServiceTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (ServiceType)value;
            var gridType = Int32.Parse(parameter.ToString());

            if (type == ServiceType.Plan)
            {
                if (gridType == 1)
                {
                    return Visibility.Collapsed;
                }

                return Visibility.Visible;

            }
            else
            {
                if (gridType == 1)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
