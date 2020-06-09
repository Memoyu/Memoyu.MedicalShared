/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels.Profile
*   文件名称 ：ProfileViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-12 17:56:23
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
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.Services;
using MedicalShredApp.Views.Profile;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using DependencyService = Xamarin.Forms.DependencyService;

namespace MedicalShredApp.ViewModels.Profile
{
    public class ProfileViewModel : BaseViewModel
    {
        #region Field

        private IPageDialogService _dialogService;
        private UserInfoModel _userInfo;
        private string _userName = "未登录";
        private string _email = "未登录";
        private string _telNol;
        private string _avatar = "Avatar.jpg";

        #endregion

        #region Prop

        public UserInfoModel UserInfo
        {
            get => _userInfo;
            set
            {
                if (value == null) return;
                _userInfo = value;
                SetProperty(ref _userInfo, value, "UserInfo");
            }
        }
        public string Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value, "Avatar");
        }
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value, "UserName");
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, "Email");
        }
        public string TelNo
        {
            get => _telNol;
            set
            {
                var con = "";
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var se = value.Substring(0, 3);
                    var en = value.Substring(value.Length - 3);
                    con = $"{se}******{en}";
                }

                SetProperty(ref _telNol, con, "TelNo");
            }
        }
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand SignOutCommand { get; set; }
        public DelegateCommand QrCodeTappedCommand { get; set; }
        public DelegateCommand MyMessageTappedCommand { get; set; }
        public DelegateCommand MyFocusTappedCommand { get; set; }
        public DelegateCommand MyReserveTappedCommand { get; set; }
        #endregion

        #region Method
        public ProfileViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            LoginCommand = new DelegateCommand(ExecLogin);
            SignOutCommand = new DelegateCommand(ExecSignOut);
            QrCodeTappedCommand = new DelegateCommand(async () => await ShowQrCode());
            MyFocusTappedCommand = new DelegateCommand(async () => await ShowMyFocus());
            MyMessageTappedCommand = new DelegateCommand(async () => await ShowMyMessage());
            MyReserveTappedCommand = new DelegateCommand(async () => await ShowMyReserve());
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters["UserInfo"] != null)
            {
                UserInfo = (UserInfoModel)parameters["UserInfo"];
                if (_userInfo == null || UserInfo.Uid == Guid.Empty)
                {
                    InitialPage();
                }
                else
                {
                    GlobalData.UserInfo = _userInfo;
                    AssignmentPage();
                }
            }
        }
        private async void ExecSignOut()
        {
            if (GlobalData.UserInfo == null || RestClientUtil.Token == null) return;
            var alert = await _dialogService.DisplayAlertAsync("退出登录", "您确定要退出登录吗？", "确定", "取消");
            if (!alert) return;
            GlobalData.UserInfo = null;
            RestClientUtil.Token = null;
            var param = new NavigationParameters();
            param.Add("UserInfo", new UserInfoModel());
            OnNavigatedTo(param);
            Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("退出登录成功！"));
        }
        private async void ExecLogin()
        {
            if (GlobalData.UserInfo == null || string.IsNullOrWhiteSpace(RestClientUtil.Token))
            {
                await NavigationService.NavigateAsync($"{ nameof(LoginPage)}");
            }
            else
            {
                var page = new UserPopupPage();
                page.BindingContext = new UserPopupViewModel();
                await PopupNavigation.Instance.PushAsync(page, true);
            }
        }
        private async Task ShowQrCode()
        {
            if (GlobalData.UserInfo == null)
            {
                await NavigationService.NavigateAsync($"{ nameof(LoginPage)}");
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new QrCodeShowPage());
            }
        }
        public async Task ShowMyMessage()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            await NavigationService.NavigateAsync($"{nameof(MyMessagePage)}");
        }
        private async Task ShowMyFocus()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            await NavigationService.NavigateAsync($"{nameof(FocusPage)}");
        }
        private async Task ShowMyReserve()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            await NavigationService.NavigateAsync($"{nameof(MyReservePage)}");
        }
        /// <summary>
        /// 赋值页面
        /// </summary>
        private void AssignmentPage()
        {
            UserName = _userInfo.UserName;
            Email = _userInfo.Email;
            TelNo = _userInfo.TelNo;
            Avatar = _userInfo.HeadIcon;
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitialPage()
        {
            UserName = "未登录";
            Email = "未登录";
            TelNo = null;
            Avatar = "Avatar.jpg";
        }
        #endregion
    }

}
