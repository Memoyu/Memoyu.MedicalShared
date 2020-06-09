/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：MyReserveViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/15 20:41:58
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
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Views.Reserve;
using Prism.Commands;
using Prism.Navigation;

namespace MedicalShredApp.ViewModels.Reserve
{
    public class MyReserveViewModel : BaseViewModel
    {
        #region Field
        private bool _isBusy;
        private ICommand _refreshCommand;
        private bool _canRefresh;
        private ObservableCollection<ReserveDoctorViewModel> _reserveDoctors;
        private DelegateCommand<ReserveDoctorViewModel> _cancelReserveCommand;
        private DelegateCommand<ReserveDoctorViewModel> _chatDoctorCommand;

        #endregion
        #region Prop
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
        public ObservableCollection<ReserveDoctorViewModel> ReserveDoctors
        {
            get => _reserveDoctors;
            set => SetProperty(ref _reserveDoctors, value, "ReserveDoctors");
        }
        public ICommand RefreshCommand => 
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(async () => { await ExecuteRefreshCommand(); }));
        public DelegateCommand<ReserveDoctorViewModel> ChatDoctorCommand =>
            _chatDoctorCommand ?? (_chatDoctorCommand = new DelegateCommand<ReserveDoctorViewModel>(async m => await ChatToDoctor(m)));
        public DelegateCommand<ReserveDoctorViewModel> CancelReserveCommand => 
            _cancelReserveCommand ?? (_cancelReserveCommand = new DelegateCommand<ReserveDoctorViewModel>(async r => { await ExecuteCancelReserveCommand(r); }));

       

        #endregion



        #region Method
        public MyReserveViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        private async Task ExecuteRefreshCommand()
        {
            if (IsBusy) return;
            IsBusy = true;
            ReserveDoctors = await Api.GetReserveDoctors(GlobalData.UserInfo.Uid);
            IsBusy = false;
        }
        private async Task ExecuteCancelReserveCommand(ReserveDoctorViewModel reserveDoctor)
        {
            bool res = Api.CancelReserveDoctor(reserveDoctor.Id);
            if (res)
            {
                await ExecuteRefreshCommand();
            }
        }
        private async Task ChatToDoctor(ReserveDoctorViewModel reserveDoctor)
        {
            var doc = reserveDoctor;
            var navParam = new NavigationParameters { { nameof(DoctorChatPage), new ChatToDoctorViewModel { DoctorName = doc.DoctorName, DoctorId = doc.DoctorId } } };
            await NavigationService.NavigateAsync($"{nameof(DoctorChatPage)}", navParam);
        }
        #endregion
    }
}
