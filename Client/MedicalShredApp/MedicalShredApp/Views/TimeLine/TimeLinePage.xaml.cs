using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.TimeLine;
using MedicalShredApp.Services;
using MedicalShredApp.ViewModels.TimeLine;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AspNetCore.SignalR.Client;

namespace MedicalShredApp.Views.TimeLine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeLinePage : ContentPage
    {
        private bool _isBackstage = false;
        private Button _lastButton;
        private TimeLineViewModel _timeLineViewModel;

        public TimeLinePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _timeLineViewModel = (TimeLineViewModel)BindingContext;
            if (GlobalData.UserInfo == null)
            {
                _timeLineViewModel.Years = null;
                _timeLineViewModel.RecipeRecords = null;
                _timeLineViewModel.CanRefresh = false;
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("请先登录！"));
                return;
            }
            AddHubMessage();
            if (_isBackstage) return;
            AssignmentTimeLine();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            RemoveHubMessage();
            _isBackstage = true;
        }
        private async void AssignmentTimeLine()
        {

            await _timeLineViewModel.GetTimelineYearData();
        }
        public void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            var model = lv.SelectedItem as RecipeRecordPreviewModel;
            lv.SelectedItem = null;
            _timeLineViewModel.GoToTimePointDetailCommand.Execute(model);
            //var page = new TimePointDetailPopupPage();
            //page.BindingContext = new TimePointDeatailPopupViewModel(model);
            //await PopupNavigation.Instance.PushAsync(page, true);

        }

        #region SignalR

        private void AddHubMessage()
        {
            //GlobalData.HubConnection.On<string>("Test", (message) =>
            //{
            //    Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert($"这是服务端发回消息：{message}"));
            //});

            GlobalData.HubConnection.On<string>(GlobalData.REFRESH_TIMELINE, async (obj) =>
            {
                if (_timeLineViewModel.YearSelected.Equals(obj))
                {
                    await _timeLineViewModel.GetTimelineData(_timeLineViewModel.YearSelected);
                }
                else
                {
                    List<string> temp = _timeLineViewModel.Years.ToList();
                    if (!temp.Exists(y => y.Equals(obj)))
                    {
                        await _timeLineViewModel.GetTimelineYearData();
                    }
                }

            });
        }
        private void RemoveHubMessage()
        {
            GlobalData.HubConnection?.Remove(GlobalData.REFRESH_TIMELINE);
        }

        #endregion

        private void Button_OnClicked(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //foreach (View child in YearEl.Children)
            //{
            //    Button year = (Button)child;
            //    VisualStateManager.GoToState(year, "YearUnSelected");
            //}
            //VisualStateManager.GoToState(btn, "YearSelected");

        }

    }
}