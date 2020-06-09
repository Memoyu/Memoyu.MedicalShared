/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Common.Converter
*   文件名称 ：TimeLineIconConverter
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-16 0:56:50
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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedicalShredApp.Common.Converter
{
    public class TimeLineIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = bool.TryParse(value.ToString(), out bool isRepeat);
            string repeatIcon1 = "Car";
            string repeatIcon2 = "Motor";
            Color repeatColor1 = ColorConverters.FromHex("#31bea6");
            Color repeatColor2 = ColorConverters.FromHex("#e0995e");
            object re = null;

            if (parameter is string par && !string.IsNullOrWhiteSpace(par))
            {
                if (isRepeat )
                {
                    if (par.Equals("Icon"))
                    {
                        re = repeatIcon1;
                    }
                    else
                    {
                        re = repeatColor1;
                    }
                }
                else
                {
                    if (par.Equals("Icon"))
                    {
                        re = repeatIcon2;
                    }
                    else
                    {
                        re = repeatColor2;
                    }
                }
            }
            return re;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Generally not needed in this scenario
            return null;
        }
    }
}
