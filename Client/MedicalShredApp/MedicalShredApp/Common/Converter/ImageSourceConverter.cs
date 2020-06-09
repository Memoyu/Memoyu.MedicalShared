/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ImageSourceConverter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/15 14:34:25
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
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace MedicalShredApp.Common.Converter
{
    public class ImageSourceConverter : IValueConverter
    {
        static WebClient Client = new WebClient();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var byteArray = Client.DownloadData(value.ToString());
                return ImageSource.FromStream(() => new MemoryStream(byteArray));
            }
            catch
            {
                return ImageSource.FromFile("Avatar.jpg");
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
