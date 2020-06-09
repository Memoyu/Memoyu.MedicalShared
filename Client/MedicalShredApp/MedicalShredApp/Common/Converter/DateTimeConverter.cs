/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：CommonConverter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/11 13:51:32
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MedicalShredApp.Common.Converter
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = DateTime.TryParse(value.ToString(), out DateTime date);
            string format = "yyyy-MM-dd HH:mm";
            // Double check we don't have a casting error
            if (!result) return string.Empty;
            if (parameter is string par && !string.IsNullOrWhiteSpace(par)) format = par;
            return date.ToString(format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Generally not needed in this scenario
            return null;
        }
    }
}
