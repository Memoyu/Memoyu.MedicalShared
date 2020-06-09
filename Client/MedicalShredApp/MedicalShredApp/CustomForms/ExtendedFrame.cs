/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ExtendedFrame
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/20 14:50:05
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MedicalShredApp.CustomForms
{
    public class ExtendedFrame:Frame
    {
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(ExtendedFrame), typeof(CornerRadius), typeof(ExtendedFrame));
        public ExtendedFrame()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
