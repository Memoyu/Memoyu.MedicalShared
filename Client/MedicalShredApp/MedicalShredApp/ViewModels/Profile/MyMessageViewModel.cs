/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels.Profile
*   文件名称 ：MyMessageViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-05-10 15:49:04
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Chat;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Views.Reserve;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.Profile
{
    public class MyMessageViewModel:BaseViewModel
    {
        #region Field
        private bool _isBusy;
        private ICommand _refreshCommand;
        private bool _canRefresh = true;
        private ObservableCollection<ChatListViewModel> _chatList;
        private DelegateCommand<ChatListViewModel> _chatDoctorCommand;
        //private DelegateCommand _chatDoctorCommand;

        #endregion

        #region Porp

        public ObservableCollection<ChatListViewModel> ChatList
        {
            get => _chatList;
            set => SetProperty(ref _chatList, value, "ChatList");
        }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value) return;
                SetProperty(ref _isBusy, value, "IsBusy");
            }
        }
        public bool CanRefresh
        {
            get => _canRefresh;
            set
            {
                if (_canRefresh == value) return;
                SetProperty(ref _canRefresh, value, "CanRefresh");
            }
        }
        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand));
        public DelegateCommand<ChatListViewModel> ChatDoctorCommand => 
            _chatDoctorCommand ?? (_chatDoctorCommand = new DelegateCommand<ChatListViewModel>(async m => await ChatToDoctor(m)));

        #endregion

        #region Method
        public MyMessageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        private async void ExecuteRefreshCommand()
        {
            if (IsBusy) return;
            IsBusy = true;
            ChatList = await Api.GetChatList(GlobalData.UserInfo.Uid);
            IsBusy = false;
        }
        private async Task ChatToDoctor(ChatListViewModel chatList)
        {
            var doc = chatList;
            var navParam = new NavigationParameters { { nameof(DoctorChatPage), new ChatToDoctorViewModel { DoctorName = doc.AnotherName, DoctorId = doc.AnotherId } } };
            await NavigationService.NavigateAsync($"{nameof(DoctorChatPage)}", navParam);
        }
        #endregion
    }
}
