/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：MyFocusNewsViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/13 20:19:14
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
using MedicalShredApp.Models.News;
using MedicalShredApp.Views.News;
using Prism.Commands;
using Prism.Navigation;

namespace MedicalShredApp.ViewModels.Profile
{
    public class MyFocusNewsViewModel:BaseViewModel
    {
        #region Field
        private ObservableCollection<NewsModel> _news;
        private bool _isBusy;
        private ICommand _refreshCommand;
        private bool _canRefresh;
        private DelegateCommand<NewsModel> _newsDetailCommand;

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
        public ObservableCollection<NewsModel> News
        {
            get => _news;
            set => SetProperty(ref _news, value, "News");
        }
        public ICommand RefreshCommand => 
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(async () => { await ExecuteRefreshCommand();}));
        public DelegateCommand<NewsModel> NewsDetailCommand =>
            _newsDetailCommand ?? (_newsDetailCommand = new DelegateCommand<NewsModel>(async m => await NewsDetail(m)));

        #endregion

        #region Method

        public MyFocusNewsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        private async Task ExecuteRefreshCommand()
        {
            if (IsBusy) return;
            IsBusy = true;
            News = await Api.GetCollectNewsDetails(GlobalData.UserInfo.Uid);
            IsBusy = false;
        }
        private async Task NewsDetail(NewsModel newsModel)
        {
            var navParam = new NavigationParameters { { nameof(NewsDetailPage), newsModel } };
            await NavigationService.NavigateAsync($"{nameof(NewsDetailPage)}", navParam);
        }

        #endregion
    }
}
