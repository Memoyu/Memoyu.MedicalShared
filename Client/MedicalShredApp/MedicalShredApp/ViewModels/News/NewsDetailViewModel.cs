/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels.News
*   文件名称 ：NewsDetailViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-12 13:36:20
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
using System.Threading.Tasks;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.News;
using MedicalShredApp.Services;
using MedicalShredApp.Views.News;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.News
{
    public class NewsDetailViewModel : BaseViewModel
    {
        #region Field
        private readonly List<Color> _startColors = new List<Color>
            {System.Drawing.Color.Black ,System.Drawing.Color.Yellow};
        private NewsModel _newsDetail;
        private DelegateCommand _commentCommand;
        private DelegateCommand _collectCommand;
        private ObservableCollection<NewsCommentModel> _comments;
        private string _commentInput;
        private Color _startColor;
        private bool _isCollect;
        private List<CollectNewsViewModel> _startCollects;

        #endregion

        #region Prop
        public Color StartColor
        {
            get => _startColor;
            set => SetProperty(ref _startColor, value, "StartColor");
        }
        public NewsModel NewsDetail
        {
            get => _newsDetail;
            set => SetProperty(ref _newsDetail, value, "NewsDetail");
        }
        public string CommentInput
        {
            get => _commentInput;
            set => SetProperty(ref _commentInput, value, "CommentInput");
        }
        public ObservableCollection<NewsCommentModel> Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value, "Comments");
        }
        public DelegateCommand CommentCommand =>
            _commentCommand ?? (_commentCommand = new DelegateCommand(async () => await CommentNews()));
        public DelegateCommand CollectCommand =>
            _collectCommand ?? (_collectCommand = new DelegateCommand(async () => await CollectNews()));


        #endregion

        #region Method
        //public NewsDetailViewModel(NewsModel news)
        //{
        //    _newsDetail = news;
        //    GetNewsDetail(_newsDetail);
        //}
        public NewsDetailViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters[nameof(NewsDetailPage)] != null)
            {
                NewsModel news = (NewsModel)parameters[nameof(NewsDetailPage)];
                GetNewsDetail(news);
                GetNewsComments(news.Id);
                GetInitialData(news);
            }
        }

        private async void GetInitialData(NewsModel news)
        {
            if (GlobalData.UserInfo != null)
            {
                _startCollects = await Api.GetCollectNews(GlobalData.UserInfo.Uid);
                if (_startCollects != null && _startCollects.Exists(d => d.NewsId.Equals(news.Id) && d.IsCollect))
                {
                    StartColor = _startColors[1];
                    _isCollect = true;
                }
                else
                {
                    StartColor = _startColors[0];
                    _isCollect = false;
                }
            }
        }

        private async void GetNewsDetail(NewsModel news)
        {
            NewsDetail = await Api.GetNewsDetail(news.Id);
        }
        private async void GetNewsComments(int newsId)
        {
            Comments = await Api.GetNewsComments(newsId);
        }
        private async Task CommentNews()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            if (string.IsNullOrWhiteSpace(CommentInput))
            {
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("别忘了输入内容哦！"));
                return;
            }
            bool res = Api.AddNewsComment(new NewsCommentAddModel
            {
                Content = CommentInput,
                NewsId = NewsDetail.Id,
                DateTime = DateTime.Now,
                Name = GlobalData.UserInfo.UserName
            });
            if (res)
            {
                GetNewsComments(NewsDetail.Id);
                CommentInput = null;
            }
        }
        private async Task CollectNews()
        {
            if (!GlobalData.JudgmentLoginState()) return;
            bool res = Api.AddCollectNews(new CollectNewsAddModel
            { 
                NewsId = NewsDetail.Id,
                Uid = GlobalData.UserInfo.Uid,
            },_isCollect);
            if (res)
            {
                StartColor = _isCollect ? _startColors[0] : _startColors[1];
                _isCollect = !_isCollect;
            }
        }

        #endregion


    }
}
