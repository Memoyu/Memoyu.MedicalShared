/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：LoginPopupViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/14 11:02:02
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Common.Tools;
using MedicalShredApp.Common.Validators;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Profile;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.Profile
{
    public class UserPopupViewModel : BindableBase
    {
        private UserInfoModel _userInfo;

        #region Field



        #endregion

        #region Porp

        public UserInfoModel UserInfo
        {
            get => _userInfo;
            set => SetProperty(ref _userInfo, value, $"{nameof(UserInfo)}");
        }

        #endregion


        #region Method
        public UserPopupViewModel()
        {
            UserInfo = GlobalData.UserInfo;
        }

        #endregion
    }
}
