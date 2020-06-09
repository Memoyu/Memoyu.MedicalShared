/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：TimeLineViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/11 1:03:09
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
using System.Windows.Input;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Services;
using MedicalShredApp.Views.TimeLine;
using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using RecipeRecordPreviewModel = MedicalShredApp.Models.TimeLine.RecipeRecordPreviewModel;
using Microsoft.AspNetCore.SignalR.Client;

namespace MedicalShredApp.ViewModels.TimeLine
{
    public class TimeLineViewModel : BaseViewModel
    {
        #region Field

        private bool _canRefresh = true;
        private bool _isBusy;
        private ICommand _refreshCommand;
        private DelegateCommand<RecipeRecordPreviewModel> _goToTimePointDetailCommand;
        private IList<RecipeRecordPreviewModel> _recipeRecords;
        private DelegateCommand _healthReportClickCommand;
        private ObservableCollection<string> _years;
        private string _yearSelected;
        private DelegateCommand<string> _yearCommand;
        private DelegateCommand _medicalRecordClickCommand;

        #endregion

        #region Prop
        public string SelectedPointId { get; set; }



        public new bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, "IsBusy");

        }
        public bool CanRefresh
        {
            get => _canRefresh;
            set => SetProperty(ref _canRefresh, value, "CanRefresh");
        }
        public IList<RecipeRecordPreviewModel> RecipeRecords
        {
            get => _recipeRecords;
            set => SetProperty(ref _recipeRecords, value, "RecipeRecords");
        }
        public ObservableCollection<string> Years
        {
            get => _years;
            set => SetProperty(ref _years, value, "Years");
        }
        public string YearSelected
        {
            get => _yearSelected;
            set => SetProperty(ref _yearSelected, value, "YearSelected");
        }

        public ICommand RefreshCommand
        {
            get { return _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }
        public DelegateCommand<string> YearCommand
        {
            get { return _yearCommand ?? (_yearCommand = new DelegateCommand<string>(async y => await ExecuteYearCommand(y))); }
        }
        public DelegateCommand<RecipeRecordPreviewModel> GoToTimePointDetailCommand
        {
            get
            {
                return _goToTimePointDetailCommand ?? (_goToTimePointDetailCommand =
                           new DelegateCommand<RecipeRecordPreviewModel>(async m => await GoToTimePointDetail(m)));
            }
        }
        public DelegateCommand HealthReportClickCommand
        {
            get
            {
                return _healthReportClickCommand ?? (_healthReportClickCommand =
                           new DelegateCommand(async () => await HealthReportClick()));
            }
        }
        public DelegateCommand MedicalRecordClickCommand
        {
            get
            {
                return _medicalRecordClickCommand ?? (_medicalRecordClickCommand =
                           new DelegateCommand(async () => await MedicalRecordClick()));
            }
        }

        #endregion

        #region Method
        public TimeLineViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddSignalREvent();
        }
        private async Task ExecuteRefreshCommand()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            if (IsBusy) return;
            IsBusy = true;
            await GetTimelineData(YearSelected);
            IsBusy = false;

        }
        private async Task ExecuteYearCommand(string year)
        {
            await GetTimelineData(year);
        }

        private async Task GoToTimePointDetail(RecipeRecordPreviewModel model)
        {
            var navParam = new NavigationParameters { { nameof(TimePointDetailPage), model } };
            await NavigationService.NavigateAsync($"{nameof(TimePointDetailPage)}", navParam);
        }
        private async Task HealthReportClick()
        {
            if (!GlobalData.JudgmentLoginState())
            {
                this.CanRefresh = false;
                return;
            }
            var page = new HealthReportPopupPage();
            page.BindingContext = new HealthReportPopupViewModel();
            await PopupNavigation.Instance.PushAsync(page, true);
        }
        private async Task MedicalRecordClick()
        {
            if (!GlobalData.JudgmentLoginState())
            {
                this.CanRefresh = false;
                return;
            }
            await NavigationService.NavigateAsync($"{nameof(MedicalRecordPage)}");
        }
        public async Task GetTimelineData(string year)
        {
            if (!string.IsNullOrWhiteSpace(year))
                RecipeRecords = (IList<RecipeRecordPreviewModel>)await Api.GetTimeLinePreview(GlobalData.UserInfo.IdNo, int.Parse(year));
        }
        public async Task GetTimelineYearData()
        {
            Years = await Api.GetTimeLineYear(GlobalData.UserInfo.IdNo);
            if (Years != null)
            {
                if (string.IsNullOrWhiteSpace(YearSelected))
                {
                    YearSelected = Years?.FirstOrDefault();
                }
                await ExecuteYearCommand(YearSelected);
            }

        }
        private void AddSignalREvent()
        {

        }

        #endregion

    }
}
