/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels.Profile
*   文件名称 ：LoginViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-12 17:56:04
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Windows.Input;
using FluentValidation;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Common.Tools;
using MedicalShredApp.Common.Validators;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.Services;
using MedicalShredApp.Views;
using MedicalShredApp.Views.Profile;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.Profile
{
    public class LoginViewModel : BaseViewModel
    {

        #region Field
        private string _userName = "Memoyu", _password = "123";
        private readonly IValidator _validator;
        #endregion;

        #region Porp

        public ICommand LoginClickCommand { get; private set; }
        public ICommand RegisteredClickCommand { get; private set; }
        public LoginModel LoginUserIns { get; set; }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value, "UserName");
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, "Password");
        }

        #endregion

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            _validator = new LoginUserValidator();
            LoginClickCommand = new DelegateCommand(LoginClick);
        }

        #region Method

        private async void LoginClick()
        {
            string msg = String.Empty;
            try
            {
                if (LoginUserIns == null)
                {
                    LoginUserIns = new LoginModel();
                }

                LoginUserIns.UserName = _userName.ToLower();
                LoginUserIns.Password = MD5Helper.GetMd5_32(_password);
                var validationResult = _validator.Validate(LoginUserIns);
                if (validationResult.IsValid)
                {
                    UserInfoModel info = Api.Login(LoginUserIns);
                    var param = new NavigationParameters();
                    param.Add("UserInfo", info);
                    if (info == null) return;
                    Device.BeginInvokeOnMainThread(async () =>
                        await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}?selectedTab={nameof(ProfilePage)}", param));
                    msg = "登陆成功！";
                    await Api.CreateHubConnection();
                    if (GlobalData.HubConnection != null && GlobalData.HubConnection.ConnectionId != null)
                    {
                        bool result = await GlobalData.HubConnection.InvokeAsync<bool>("USER_LOGIN", info.UserName, info.Uid);
                    }

                }
                else
                {
                    msg = validationResult.Errors[0].ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }

            Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
        }
        #endregion
    }
}
