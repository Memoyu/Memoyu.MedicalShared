/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels.Reserve
*   文件名称 ：ReserveViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-14 22:03:25
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
using System.Linq;
using System.Threading.Tasks;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Services;
using MedicalShredApp.Views.Reserve;
using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.Reserve
{
    public class ReserveViewModel : BaseViewModel
    {
        #region Field

        private int _index = 0;
        private int _size = 6;
        private int _count = 0;


        private IList<HospitalViewModel> _hospitals;
        private bool _isLoadBusy;
        private bool _isUpLoadMore;
        private HospitalViewModel _currentHospital;
        private ObservableCollection<DoctorViewModel> _doctors;
        private INavigationService _navigationService;

        #endregion

        #region Prop
        public ObservableCollection<DoctorViewModel> Doctors
        {
            get => _doctors;
            set => SetProperty(ref _doctors, value, "Doctors");
        }
        public IList<HospitalViewModel> Hospitals
        {
            get => _hospitals;
            set => SetProperty(ref _hospitals, value, "Hospitals");
        }
        public HospitalViewModel CurrentHospital
        {
            get => _currentHospital;
            set => SetProperty(ref _currentHospital, value, "CurrentHospital");
        }
        public bool IsLoadBusy
        {
            get => _isLoadBusy;
            set => SetProperty(ref _isLoadBusy, value, "IsLoadBusy");
        }
        public bool IsUpLoadMore
        {
            get => _isUpLoadMore;
            set => SetProperty(ref _isUpLoadMore, value, "IsUpLoadMore");
        }
        public DelegateCommand<HospitalViewModel> CurrentHospitalChangedCommand { get; set; }
        public DelegateCommand<string> SearchHosTextChangedCommand { get; set; }
        public DelegateCommand<string> SearchDocCommand { get; set; }
        public DelegateCommand LoadMoreCommand { get; set; }
        public DelegateCommand AddReserveDoctor { get; set; }
        public DelegateCommand<DoctorViewModel> GoToDetailCommand { get; set; }
        public DelegateCommand CurrentReserveCommand { get; set; }
        public DelegateCommand ReserveRecordCommand { get; set; }
        public DelegateCommand SmartDiagnosisCommand { get; set; }
        #endregion

        #region Method
        public ReserveViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            SearchHosTextChangedCommand = new DelegateCommand<string>(async i => await SearchHospitalInfo(i));
            SearchDocCommand = new DelegateCommand<string>(async i => await SearchDoctorInfo(i));
            CurrentHospitalChangedCommand = new DelegateCommand<HospitalViewModel>(async h => await LoadData(h));
            LoadMoreCommand = new DelegateCommand(async () => await LoadMoreData());
            GoToDetailCommand = new DelegateCommand<DoctorViewModel>(async d => await ShowDoctorDetail(d));
            ReserveRecordCommand = new DelegateCommand(async () => await ReserveRecordList());
            SmartDiagnosisCommand = new DelegateCommand(async () => await SmartDiagnosis());
        }

        private async Task LoadData(HospitalViewModel hospital)
        {
            IsUpLoadMore = true;
            _index = 0;
            var pageData = await Api.GetDoctorsPage(hospital?.HosCode, _index, _size * 2);
            if (pageData== null)
            {
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("当前医院不存在医生信息！"));
                Doctors = null;
                return;
            }
            _count = pageData.Count;
            Doctors = pageData.Data;
        }
        private async Task LoadMoreData()
        {
            IsLoadBusy = true;
            if (Doctors.Count < _count)
            {
                _index = Doctors.Count;
                var pageData = await Api.GetDoctorsPage(CurrentHospital?.HosCode, _index, _size);
                ObservableCollection<DoctorViewModel> temp = Doctors;
                _count = pageData.Count;
                foreach (DoctorViewModel doctor in pageData.Data)
                {
                    temp.Insert(Doctors.Count, doctor);
                }
                Doctors = temp;
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("已经没有更多了！"));
            }
            IsLoadBusy = false;
        }
        private async Task SearchHospitalInfo(string input)
        {
            var hospitals = await Api.GetHospitalsByName(input);
            Hospitals = (IList<HospitalViewModel>)hospitals;
            CurrentHospital = hospitals.FirstOrDefault();
        }
        private async Task SearchDoctorInfo(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                await LoadData(CurrentHospital);
            }
            else
            {
                IsUpLoadMore = false;
                var doctors = await Api.GetDoctorsByName(CurrentHospital.HosCode, input);
                Doctors = doctors;
            }

        }
        private async Task ShowDoctorDetail(DoctorViewModel doctor)
        {
            var page = new DoctorDetailPopupPage();
            page.BindingContext = new DoctorDetailPopupViewModel(_navigationService , doctor , page);
            await PopupNavigation.Instance.PushAsync(page, true);
        }
        private async Task ReserveRecordList()
        {
            var page = new ReserveRecordPopupPage();
            page.BindingContext = new ReserveRecordPopupViewModel();
            await PopupNavigation.Instance.PushAsync(page, true);
        }
        private async Task SmartDiagnosis()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            await NavigationService.NavigateAsync($"{nameof(SmartDiagnosisPage)}");
        }
        #endregion
    }
}
