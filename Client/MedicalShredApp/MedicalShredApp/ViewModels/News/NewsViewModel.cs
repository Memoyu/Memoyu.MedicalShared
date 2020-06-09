/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：NewsViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/11 9:36:42
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
using MedicalShredApp.Models.News;
using MedicalShredApp.Services;
using MedicalShredApp.Views.News;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.News
{
    public class NewsViewModel : BaseViewModel
    {

        #region Field
        private int _index = 0;
        private int _size = 10;
        private int _count = 0;
        private bool _isBusy;
        private ICommand _refreshCommand;
        private bool _canRefresh = true;
        private IList<NewsModel> _newsData;
        private ICommand _loadMoreNews;
        private DelegateCommand<NewsModel> _newsDetailCommand;

        #endregion

        #region Porp

        public IList<NewsModel> NewsData
        {
            get => _newsData;
            set => SetProperty(ref _newsData, value, "NewsData");
        }
        public IList<TopNewsModel> TopNews { get; set; }
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
        public ICommand SelectPreview { get; set; }
        public DelegateCommand<NewsModel> NewsDetailCommand =>
            _newsDetailCommand ?? (_newsDetailCommand = new DelegateCommand<NewsModel>(async m => await NewsDetail(m)));

        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand));
        public ICommand LoadMoreNews => _loadMoreNews ?? (_loadMoreNews = new DelegateCommand(ExecuteLoadMoreNewsCommand));
        #endregion

        #region Method
        public NewsViewModel(INavigationService navigationService) : base(navigationService)
        {

            SelectPreview = new Command(() =>
            {
                Console.WriteLine("点击");
            });
        }

        private async void ExecuteRefreshCommand()
        {
            if (IsBusy) return;
            _index = 0;
            IsBusy = true;
            NewsData?.Clear();
            NewsPageModel newsPage = await Api.GetNews(new PageInquireModel { Index = _index, Size = _size });
            _count = newsPage?.Count ?? 0;
            NewsData = newsPage?.Data;
            IsBusy = false;
            //page.DisplayAlert("Refreshed", "You just refreshed the page! Nice job! Pull to refresh is now disabled", "OK");
            //this.CanRefresh = false;
        }
        private async void ExecuteLoadMoreNewsCommand()
        {
            if (NewsData.Count >= _count)
            {
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("已经没有更多了！"));
                return;
            }
            _index = _index + _size;
            NewsPageModel newsPage = await Api.GetNews(new PageInquireModel { Index = _index, Size = _size });
            NewsData = (IList<NewsModel>)NewsData.Union(newsPage.Data).ToList();
        }
        private async Task NewsDetail(NewsModel newsModel)
        {
            var navParam = new NavigationParameters { { nameof(NewsDetailPage), newsModel} };
            await NavigationService.NavigateAsync($"{nameof(NewsDetailPage)}", navParam);
        }
        #endregion

    }
}
