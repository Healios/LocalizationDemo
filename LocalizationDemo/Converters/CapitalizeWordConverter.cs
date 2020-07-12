using System;
using System.Globalization;
using Xamarin.Forms;

namespace LocalizationDemo.Converters
{
    internal class CapitalizeWordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => culture.TextInfo.ToTitleCase(value as string);
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value as string;
    }
}
