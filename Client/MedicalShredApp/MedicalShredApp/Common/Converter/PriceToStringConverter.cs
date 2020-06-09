using System;
using System.Globalization;
using Xamarin.Forms;

namespace FreshApp.Converters
{
    public class PriceToStringConverter : IValueConverter
    {
        public bool IsDec { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (double)value;
            string stringVal = val.ToString("0.00", CultureInfo.InvariantCulture);
            string[] parts = stringVal.Split('.');
            int yuan = int.Parse(parts[0]);
            int dec = int.Parse(parts[1]);
            if (IsDec)
                return $".{dec}";
            else
                return yuan;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
