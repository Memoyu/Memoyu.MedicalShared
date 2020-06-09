/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Common.Converter
*   文件名称 ：RecipeTypeConverter
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-23 20:18:51
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Globalization;
using System.Linq;
using MedicalShredApp.Models.Common;
using Xamarin.Forms;

namespace MedicalShredApp.Common.Converter
{
    public class BloodTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (int)value;
            return GlobalData.BloodTypes.FirstOrDefault(r => r.Id == val)?.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
