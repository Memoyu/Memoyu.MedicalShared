/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：TimePointDetailViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/21 14:30:32
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
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.TimeLine;
using MedicalShredApp.Views.TimeLine;
using Prism.Navigation;

namespace MedicalShredApp.ViewModels.TimeLine
{
    public class TimePointDetailViewModel : BaseViewModel
    {
        #region Field

        private RecipeRecordPreviewModel _recipeRecordPreview;
        private RecipeRecordModel _recipeRecord;
        private ObservableCollection<RecipeDetailModel> _recipeDetails;
        private decimal _totalAmount;
        private string _recipeNo;

        #endregion

        #region Prop

        public RecipeRecordPreviewModel RecipeRecordPreview
        {
            get => _recipeRecordPreview;
            set { _recipeRecordPreview = value; LoadPageData(); }
        }

        public RecipeRecordModel RecipeRecord
        {
            get => _recipeRecord;
            set => SetProperty(ref _recipeRecord, value, $"{nameof(RecipeRecord)}");
        }
        public ObservableCollection<RecipeDetailModel> RecipeDetails
        {
            get => _recipeDetails;
            set => SetProperty(ref _recipeDetails, value, $"{nameof(RecipeDetails)}");
        }
        public decimal TotalAmount
        {
            get => _totalAmount;
            set => SetProperty(ref _totalAmount, value, $"{nameof(TotalAmount)}");
        }
        public string RecipeNo
        {
            get => _recipeNo;
            set => SetProperty(ref _recipeNo, value, $"{nameof(RecipeNo)}");
        }
        #endregion

        #region Method
        public TimePointDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters[$"{nameof(TimePointDetailPage)}"] != null)
            {
                RecipeRecordPreviewModel model = (RecipeRecordPreviewModel)parameters[$"{nameof(TimePointDetailPage)}"];
                RecipeRecordPreview = model;
            }
        }
        private async void LoadPageData()
        {
            RecipeRecord = await Api.GetRecipeRecord(_recipeRecordPreview.Id);
            RecipeDetails = await Api.GetRecipeDetail(_recipeRecordPreview.RegisteredNo);
            decimal temp = 0;
            foreach (RecipeDetailModel detail in RecipeDetails)
            {
                temp += detail.Money;
            }
            TotalAmount = temp;
            RecipeNo = RecipeDetails.FirstOrDefault()?.RecipesNo;
        }
        #endregion
    }
}
