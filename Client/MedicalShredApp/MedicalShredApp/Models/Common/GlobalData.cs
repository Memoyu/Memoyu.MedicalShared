/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：GlobalData
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/13 16:10:24
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
using System.Threading.Tasks;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Dics;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace MedicalShredApp.Models.Common
{
    public class GlobalData
    {

        private static IEnumerable<DicJobModel> _jobTypes;
        private static IEnumerable<DicBloodTypeModel> _bloodTypes;
        private static IEnumerable<DicProvinceModel> _provinces;
        private static IEnumerable<DicRecipeTypeModel> _recipeTypes;
        private static IEnumerable<DicFrequencyModel> _frequencys;

        public static IEnumerable<DicJobModel> JobTypes
        {
            get => _jobTypes ?? (_jobTypes = Api.GetJobTypes());
            set => _jobTypes = value;
        }
        public static IEnumerable<DicBloodTypeModel> BloodTypes
        {
            get => _bloodTypes ?? (_bloodTypes = Api.GetBloodTypes());
            set => _bloodTypes = value;
        }
        public static IEnumerable<DicProvinceModel> Provinces
        {
            get => _provinces ?? (_provinces = Api.GetProvinces());
            set => _provinces = value;
        }
        public static IEnumerable<DicRecipeTypeModel> RecipeTypes
        {
            get => _recipeTypes ?? (_recipeTypes = Api.GetRecipeTypes());
            set => _recipeTypes = value;
        }
        public static IEnumerable<DicFrequencyModel> Frequencys
        {
            get => _frequencys ?? (_frequencys = Api.GetFrequencys());
            set => _frequencys = value;
        }
        public static UserInfoModel UserInfo { get; set; }

        public static string Token { get; set; }

        #region Method

        public static bool JudgmentLoginState()
        {
            if (UserInfo == null)
            {
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("请先登录！"));
                return false;
            }

            return true;
        }

        #endregion

        #region SignalR

        public static HubConnection HubConnection { get; set; }

        public static readonly string SEND_MESSAGE = "SEND_MESSAGE";
        public static readonly string REFRESH_TIMELINE = "REFRESH_TIMELINE";
        #endregion

    }
}
