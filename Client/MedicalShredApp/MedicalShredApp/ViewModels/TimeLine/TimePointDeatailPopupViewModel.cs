/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：TimePointDeatailPopupViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/16 13:37:52
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using MedicalShredApp.Models.TimeLine;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.TimeLine
{
    public class TimePointDeatailPopupViewModel : BindableBase
    {
        #region Field
        private RecipeRecordPreviewModel _recipeRecord = null;

        #endregion

        #region Prop



        #endregion

        #region Method

        public TimePointDeatailPopupViewModel(RecipeRecordPreviewModel recipeRecord)
        {
            _recipeRecord = recipeRecord;
            AssignmentPage();
        }

        private void AssignmentPage()
        {
            
        }

        #endregion   
    }
}
