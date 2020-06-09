/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：MyStartDcotorViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/13 20:01:12
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
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.ViewModels.Reserve;
using MedicalShredApp.Views.Reserve;
using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;

namespace MedicalShredApp.ViewModels.Profile
{
    public class MyStartDcotorViewModel : BaseViewModel
    {
        private ObservableCollection<FollowDoctorDetailModel> _followDoctors;
        private bool _isBusy;
        private ICommand _refreshCommand;
        private bool _canRefresh;
        private DelegateCommand<FollowDoctorDetailModel> _chatDoctorCommand;
        private DelegateCommand<FollowDoctorDetailModel> _doctorDetailCommand;
        private INavigationService _navigationService;

        #region Porp
        public new bool IsBusy
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
        public ObservableCollection<FollowDoctorDetailModel> FollowDoctors
        {
            get => _followDoctors;
            set => SetProperty(ref _followDoctors, value, "FollowDoctors");
        }
        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand));
        public DelegateCommand<FollowDoctorDetailModel> ChatDoctorCommand =>
            _chatDoctorCommand ?? (_chatDoctorCommand = new DelegateCommand<FollowDoctorDetailModel>(async m => await ChatToDoctor(m)));
        public DelegateCommand<FollowDoctorDetailModel> DoctorDetailCommand =>
            _doctorDetailCommand ?? (_doctorDetailCommand = new DelegateCommand<FollowDoctorDetailModel>(async m => await DoctorDetail(m)));

        #endregion

        #region Method
        public MyStartDcotorViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

        }
        private async void ExecuteRefreshCommand()
        {
            if (IsBusy) return;
            IsBusy = true;
            FollowDoctors = await Api.GetFollowDoctorDetails(GlobalData.UserInfo.Uid);
            IsBusy = false;
        }
        private async Task ChatToDoctor(FollowDoctorDetailModel chatList)
        {
            var doc = chatList;
            var navParam = new NavigationParameters { { nameof(DoctorChatPage), new ChatToDoctorViewModel { DoctorName = doc.DoctorName, DoctorId = doc.Id } } };
            await NavigationService.NavigateAsync($"{nameof(DoctorChatPage)}", navParam);
        }
        private async Task DoctorDetail(FollowDoctorDetailModel followDoctor)
        {
            var page = new DoctorDetailPopupPage();
            var doctor = await Api.GetDoctorDetail(followDoctor.Id);
            if (doctor == null) return;
            page.BindingContext = new DoctorDetailPopupViewModel(_navigationService, doctor, page);
            await PopupNavigation.Instance.PushAsync(page, true);
        }
        #endregion
    }
}
