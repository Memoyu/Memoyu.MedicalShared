/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Action.Api
*   文件名称 ：Api
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-12 23:40:27
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
using MedicalShredApp.Models.Chat;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Dics;
using MedicalShredApp.Models.News;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Models.TimeLine;
using MedicalShredApp.Services;
using MedicalShredApp.ViewModels.Reserve;
using Microsoft.AspNetCore.SignalR.Client;
using Models.Reserve;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MedicalShredApp.Action.Api
{
    public class Api
    {
        #region SignalR

        public static async Task CreateHubConnection()
        {
            GlobalData.HubConnection = new HubConnectionBuilder()
                 .WithUrl($"{RestClientUtil.BaseAddress}/MedicalSharedHub")
                 .Build();
            try
            {
                await GlobalData.HubConnection.StartAsync();
            }
            catch (Exception e)
            {
                throw new Exception("SignalR连接异常！", e);
            }
        }

        #endregion

        #region 字典数据
        public static IEnumerable<DicJobModel> GetJobTypes()
        {
            return ParseResponseJsonContent.ParseList<DicJobModel>(RestClientUtil.GetUnToken("/api/DicJob/Gets"), out string msg);
        }
        public static IEnumerable<DicBloodTypeModel> GetBloodTypes()
        {
            return ParseResponseJsonContent.ParseList<DicBloodTypeModel>(RestClientUtil.GetUnToken("/api/DicBloodType/Gets"), out string msg);
        }
        public static IEnumerable<DicProvinceModel> GetProvinces()
        {
            return ParseResponseJsonContent.ParseList<DicProvinceModel>(RestClientUtil.GetUnToken("/api/DicProvince/Gets"), out string msg);
        }
        public static IEnumerable<DicCityModel> GetCites(int? provinceId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/DicCity/GetsByProvince", new Dictionary<string, string>
            {
                {"provinceId", provinceId?.ToString()}
            });
            return ParseResponseJsonContent.ParseList<DicCityModel>(RestClientUtil.GetUnToken(url), out string msg);
        }
        public static IEnumerable<DicAreaModel> GetAreas(int? cityId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/DicArea/GetsByCity", new Dictionary<string, string>
            {
                {"cityId", cityId?.ToString()}
            });
            return ParseResponseJsonContent.ParseList<DicAreaModel>(RestClientUtil.GetUnToken(url), out string msg);
        }
        public static IEnumerable<DicRecipeTypeModel> GetRecipeTypes()
        {
            return ParseResponseJsonContent.ParseList<DicRecipeTypeModel>(RestClientUtil.GetUnToken("/api/DicRecipeType/Gets"), out string msg);
        }
        public static IEnumerable<DicFrequencyModel> GetFrequencys()
        {
            return ParseResponseJsonContent.ParseList<DicFrequencyModel>(RestClientUtil.GetUnToken("/api/DicFrequency/Gets"), out string msg);
        }
        #endregion

        #region 医院数据

        public static async Task<IEnumerable<HospitalViewModel>> GetHospitals()
        {
            string content = await RestClientUtil.GetUnTokenAsync("/api/HospitalInfo/Gets");
            return await Task.Run(() => ParseResponseJsonContent.ParseList<HospitalViewModel>(content, out string msg));
        }
        public static async Task<IEnumerable<HospitalViewModel>> GetHospitalsByName(string input)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/HospitalInfo/GetsByName", new Dictionary<string, string>
            {
                {"name", input}
            });
            string content = await RestClientUtil.GetUnTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseList<HospitalViewModel>(content, out string msg));
        }
        public static async Task<PageDataModel<DoctorViewModel>> GetDoctorsPage(string hosCode, int index, int size)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/DoctorInfo/GetsPage", new Dictionary<string, string>
            {
                {"hosCode", hosCode},{"index", index.ToString()},{"size", size.ToString()}
            });
            string content = await RestClientUtil.GetUnTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObj<PageDataModel<DoctorViewModel>>(content, out string msg));
        }
        public static async Task<ObservableCollection<DoctorViewModel>> GetDoctorsByName(string hosCode, string name)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/DoctorInfo/GetsByName", new Dictionary<string, string>
            {
                {"hosCode", hosCode},  {"name", name}
            });
            string content = await RestClientUtil.GetUnTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<DoctorViewModel>(content, out string msg));
        }
        public static async Task<DoctorViewModel> GetDoctorDetail(Guid doctorId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/DoctorInfo/Get", new Dictionary<string, string>
            {
                {"id", doctorId.ToString()}
            });
            string msg = String.Empty;
            string content = await RestClientUtil.GetUnTokenAsync(url);
            var data = await Task.Run(() => ParseResponseJsonContent.ParseObj<DoctorViewModel>(content, out msg));
            if (data == null)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            return data;
        }

        #endregion

        #region 用户操作
        public static UserInfoModel Registered(UserInfoModel info)
        {
            string url = "/api/UserInfo/Register";
            string input = JsonConvert.SerializeObject(info);
            RegisteredReturnModel returnModel = ParseResponseJsonContent.ParseObj<RegisteredReturnModel>(RestClientUtil.PostUnToken(url, input), out string msg);
            if (returnModel == null)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            RestClientUtil.Token = returnModel?.Access_token;
            return returnModel?.UserInfo;
        }
        public static UserInfoModel Login(LoginModel info)
        {
            string url = "/api/UserInfo/Login";
            string input = JsonConvert.SerializeObject(info);
            RegisteredReturnModel returnModel = ParseResponseJsonContent.ParseObj<RegisteredReturnModel>(RestClientUtil.PostUnToken(url, input), out string msg);
            if (returnModel == null)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            RestClientUtil.Token = returnModel?.Access_token;
            return returnModel?.UserInfo;
        }
        public static async Task<List<FollowDoctorModel>> GetStartDoctors(Guid userId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserFollowDoctor/Gets", new Dictionary<string, string>
            {
                {"uid", userId.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return (List<FollowDoctorModel>)await Task.Run(() => ParseResponseJsonContent.ParseList<FollowDoctorModel>(content, out string msg));
        }
        public static bool StartDoctor(FollowDoctorModel info)
        {
            string url = "/api/UserFollowDoctor/Add";
            string input = JsonConvert.SerializeObject(info);
            bool res = ParseResponseJsonContent.ParseBool(RestClientUtil.PostToken(url, input), out string msg);
            if (!res)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            else
            {
                string hint = info.IsFollow ? "取消关注医生成功！" : "关注医生成功！";
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(hint));
            }
            return res;
        }
        public static async Task<ObservableCollection<FollowDoctorDetailModel>> GetFollowDoctorDetails(Guid userId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserFollowDoctor/GetsDoctorDetail", new Dictionary<string, string>
            {
                {"uid", userId.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<FollowDoctorDetailModel>(content, out string msg));
        }
        public static bool AddReserveDoctor(ReserveDoctorAddModel info)
        {
            string url = "/api/UserReserveRecord/Add";
            string input = JsonConvert.SerializeObject(info);
            bool res = ParseResponseJsonContent.ParseBool(RestClientUtil.PostToken(url, input), out string msg);
            if (!res)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            else
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("预约成功！"));
            return res;
        }
        public static async Task<ObservableCollection<ReserveDoctorViewModel>> GetReserveDoctors(Guid uid)
        {

            string url = RestClientUtil.GetSpliceUrl("/api/UserReserveRecord/Gets", new Dictionary<string, string>
            {
                {"uid", uid.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<ReserveDoctorViewModel>(content, out string msg));
        }
        public static bool CancelReserveDoctor(int id)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserReserveRecord/Delete", new Dictionary<string, string>
            {
                {"id", id.ToString()}
            });
            bool res = ParseResponseJsonContent.ParseBool(RestClientUtil.DeleteToken(url), out string msg);
            if (!res)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            else
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("取消预约成功！"));
            return res;
        }
        #endregion

        #region 聊天
        public static async Task<ChatMainModel> GetChatInfo(Guid userId, Guid anotherId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/ChatMain/Get", new Dictionary<string, string>
            {
                {"userId", userId.ToString()},{"anotherId", anotherId.ToString()},
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObj<ChatMainModel>(content, out string msg));
        }
        public static async Task<ObservableCollection<ChatListViewModel>> GetChatList(Guid userId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/ChatList/GetsByUser", new Dictionary<string, string>
            {
                {"userId", userId.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<ChatListViewModel>(content, out string msg));
        }
        public static async Task<ObservableCollection<ChatContentViewModel>> GetChatContent(int chatId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/ChatContent/Gets", new Dictionary<string, string>
            {
                {"chatId", chatId.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<ChatContentViewModel>(content, out string msg));
        }
        public static bool SendChatContent(ChatContentModel chatContent)
        {
            string url = "/api/ChatContent/Add";
            string input = JsonConvert.SerializeObject(chatContent);
            bool result = ParseResponseJsonContent.ParseBool(RestClientUtil.PostToken(url, input), out string msg);
            if (!result)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            return result;
        }


        #endregion

        #region 新闻

        public static async Task<NewsPageModel> GetNews(PageInquireModel page)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/News/GetsPage", new Dictionary<string, string>
            {
                {"Index", page.Index.ToString()}, {"Size", page.Size.ToString()}
            });
            string content = await RestClientUtil.GetUnTokenAsync(url);
            return await Task.Run(function: () => ParseResponseJsonContent.ParseObj<NewsPageModel>(content, out string msg));
        }
        public static async Task<NewsModel> GetNewsDetail(int id)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/News/Get", new Dictionary<string, string>
            {
                {"Id", id.ToString()}
            });
            string content = await RestClientUtil.GetUnTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObj<NewsModel>(content, out string msg));
        }
        public static bool AddNewsComment(NewsCommentAddModel comment)
        {
            string url = "/api/NewsComment/Add";
            string input = JsonConvert.SerializeObject(comment);
            bool res = ParseResponseJsonContent.ParseBool(RestClientUtil.PostToken(url, input), out string msg);
            if (!res)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            else
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("评论成功！"));
            return res;
        }
        public static async Task<ObservableCollection<NewsCommentModel>> GetNewsComments(int id)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/NewsComment/Gets", new Dictionary<string, string>
            {
                {"Id", id.ToString()}
            });
            string content = await RestClientUtil.GetUnTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<NewsCommentModel>(content, out string msg));
        }
        public static bool AddCollectNews(CollectNewsAddModel info , bool isCollect)
        {
            string url = "/api/UserCollectNews/Add";
            string input = JsonConvert.SerializeObject(info);
            bool res = ParseResponseJsonContent.ParseBool(RestClientUtil.PostToken(url, input), out string msg);
            if (!res)
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(msg));
            else
            {
                string hint = isCollect ? "取消收藏成功！" : "收藏成功！";
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(hint));
            }
            return res;
        }
        public static async Task<List<CollectNewsViewModel>> GetCollectNews(Guid userId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserCollectNews/Gets", new Dictionary<string, string>
            {
                {"uid", userId.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return (List<CollectNewsViewModel>)await Task.Run(() => ParseResponseJsonContent.ParseList<CollectNewsViewModel>(content, out string msg));
        }
        public static async Task<ObservableCollection<NewsModel>> GetCollectNewsDetails(Guid userId)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserCollectNews/GetsNewsDetail", new Dictionary<string, string>
            {
                {"uid", userId.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<NewsModel>(content, out string msg));
        }
        #endregion

        #region 时间轴

        public static async Task<ObservableCollection<string>> GetTimeLineYear(string idNo)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserRecipeRecord/GetTimeLineByIdNo", new Dictionary<string, string>
            {
                {"IdNo", idNo}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() =>
            {
                string msg = String.Empty;
                if (!string.IsNullOrWhiteSpace(content))
                {
                    try
                    {
                        var obj = JsonConvert.DeserializeObject<ResponseBaseModel>(content);
                        if (obj.code == 0)
                        {
                            if (!string.IsNullOrEmpty(obj.data.ToString()))
                            {

                                var temp = JsonConvert.DeserializeObject<ObservableCollection<string>>(obj.data.ToString());
                                msg = obj.msg;
                                return temp;
                            }
                        }
                        msg = obj.msg;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        //logger.ErrorLog($"JSON->List数据反序列化出错！", ex);
                        throw new Exception($"JSON->List数据反序列化出错！", ex);
                    }
                }
                msg = "响应返回数据为空！";
                return null;
            });
        }
        public static async Task<IEnumerable<RecipeRecordPreviewModel>> GetTimeLinePreview(string idNo, int year)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserRecipeRecord/GetPageByIdNoYear", new Dictionary<string, string>
            {
                {"IdNo", idNo},{"Year", year.ToString()},
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseList<RecipeRecordPreviewModel>(content, out string msg));
        }
        public static async Task<RecipeRecordModel> GetRecipeRecord(int id)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserRecipeRecord/GetById", new Dictionary<string, string>
            {
                {"Id", id.ToString()}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObj<RecipeRecordModel>(content, out string msg));
        }
        public static async Task<ObservableCollection<RecipeDetailModel>> GetRecipeDetail(string registeredNo)
        {
            string url = RestClientUtil.GetSpliceUrl("/api/UserRecipeDetail/GetsByRegisteredNo", new Dictionary<string, string>
            {
                {"registeredNo", registeredNo}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseObCollection<RecipeDetailModel>(content, out string msg));
        }
        public static async Task<IEnumerable<RecipeRecordPreviewModel>> GetMedicalRecord(string idNo)
        {
            string url = RestClientUtil.GetSpliceUrl("", new Dictionary<string, string>
            {
                {"IdNo", idNo}
            });
            string content = await RestClientUtil.GetTokenAsync(url);
            return await Task.Run(() => ParseResponseJsonContent.ParseList<RecipeRecordPreviewModel>(content, out string msg));
        }
        #endregion
    }
}
