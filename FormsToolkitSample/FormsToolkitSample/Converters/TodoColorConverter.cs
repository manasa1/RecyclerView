using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsToolkitSample.Converters
{
    public class TodoColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return (bool) value ? Color.Green : Color.Red;
            return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Convert(value, targetType, parameter, culture);
    }
}
