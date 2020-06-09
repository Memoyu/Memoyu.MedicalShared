/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：SettingViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/15 12:38:30
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
using MedicalShredApp.Models.Common;
using Prism.Navigation;

namespace MedicalShredApp.ViewModels.Profile
{
    public class SettingViewModel:BaseViewModel
    {
        public SettingViewModel(INavigationService navigationService) : base(navigationService)
        {
            var con = GlobalData.HubConnection;
        }
    }
}
