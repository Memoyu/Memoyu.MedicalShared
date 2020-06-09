/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：DoctorDetailPopupViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/21 10:48:20
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Views.Reserve;
using Models.Reserve;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.Reserve
{
    public class DoctorDetailPopupViewModel : BaseViewModel
    {


        #region Field
        private readonly List<Color> _startColors = new List<Color>
        {System.Drawing.Color.Gainsboro ,System.Drawing.Color.Yellow};
        private DoctorViewModel _doctor;
        private ICommand _doctorChatClickCommand;
        private PopupPage _page;
        private ICommand _reserveClickCommand;
        private Color _startColor;
        private ICommand _startDoctorCommand;
        private List<FollowDoctorModel> _startDoctors;
        private bool _isFollow;
        private string _reserveDate;

        #endregion

        #region Prop

        public Color StartColor
        {
            get => _startColor;
            set => SetProperty(ref _startColor, value, "StartColor");
        }
        public DoctorViewModel Doctor
        {
            get => _doctor;
            set => SetProperty(ref _doctor, value, "Doctor");
        }

        public string ReserveDate
        {
            get => _reserveDate;
            set => SetProperty(ref _reserveDate, value, "ReserveDate");
        }
        public ICommand DoctorChatClickCommand => _doctorChatClickCommand ?? (_doctorChatClickCommand = new DelegateCommand(DoctorChat));
        public ICommand ReserveClickCommand => _reserveClickCommand ?? (_reserveClickCommand = new DelegateCommand(ReserveDoctor));
        public ICommand StartDoctorCommand => _startDoctorCommand ?? (_startDoctorCommand = new DelegateCommand(StartDoctor));

        #endregion

        #region Medthod

        public DoctorDetailPopupViewModel(INavigationService navigationService, DoctorViewModel doctor, PopupPage page) : base(navigationService)
        {
            _startColor = _startColors[0];
            Doctor = doctor;
            _page = page;
            GetInitialData();
        }

        private async void GetInitialData()
        {
            if (GlobalData.UserInfo != null)
            {
                _startDoctors = await Api.GetStartDoctors(GlobalData.UserInfo.Uid);
                if (_startDoctors != null && _startDoctors.Exists(d => d.DoctorId.Equals(Doctor.Id) && d.IsFollow))
                {
                    StartColor = _startColors[1];
                    _isFollow = true;
                }
                else
                {
                    StartColor = _startColors[0];
                    _isFollow = false;
                }
            }
        }

        private async void DoctorChat()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            await PopupNavigation.Instance.RemovePageAsync(_page, true);
            var navParam = new NavigationParameters { { nameof(DoctorChatPage), new ChatToDoctorViewModel { DoctorName = Doctor.DoctorName, DoctorId = Doctor.Id } } };
            await NavigationService.NavigateAsync($"{nameof(DoctorChatPage)}", navParam);
        }
        private void ReserveDoctor()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            bool res = Api.AddReserveDoctor(new ReserveDoctorAddModel
            {
                DoctorId = Doctor.Id,
                Uid = GlobalData.UserInfo.Uid,
                ReserveDate = DateTime.Parse(ReserveDate)
            });
        }
        private void StartDoctor()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            //FollowDoctorModel info = null;
            //if (_startDoctors != null)
            //    info = _startDoctors.FirstOrDefault(d => d.DoctorId.Equals(Doctor.Id));
            bool res = Api.StartDoctor(new FollowDoctorModel
            {
                DoctorId = Doctor.Id,
                Uid = GlobalData.UserInfo.Uid,
                IsFollow = _isFollow
            });
            if (res)
            {
                StartColor = _isFollow? _startColors[0]: _startColors[1];
                _isFollow = !_isFollow;
            }

        }

        #endregion


    }
}
