using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Metro.Dialogs
{
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter!=null && parameter.Equals("hidden"))  
                return ((bool)value) ? Visibility.Hidden : Visibility.Visible;
            return ((bool)value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}