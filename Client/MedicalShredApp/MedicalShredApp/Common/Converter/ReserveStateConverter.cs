/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ReserveStateConverter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/15 21:33:31
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
    public class ReserveStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (int)value;
            Color color = Color.White;
            switch (val)
            {
                case 0:
                    color = Color.Gainsboro;
                    break;
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.Green;
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
