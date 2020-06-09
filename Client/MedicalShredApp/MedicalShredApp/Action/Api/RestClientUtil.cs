/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Action.Api
*   文件名称 ：RestClientUtil
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-12 23:40:53
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MedicalShredApp.Common.Exceptions;
using MedicalShredApp.Models.Common;
using RestSharp;

namespace MedicalShredApp.Action.Api
{
    public class RestClientUtil
    {
        public static string BaseAddress ="http://39.108.97.141:80";
        public static string Token = null;
        internal static RestClient Instance(string url)
        {
            var restClient = new RestClient(url)
            {
                Timeout = 5000,
                ReadWriteTimeout = 5000
            };
            return restClient;
        }
        public static string PostToken(string url, string body)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {Token}");//添加请求头参数
            request.AddJsonBody(body);
            var response = restClient.Post(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new MUnauthorizedException("请先登录！");
            }
            
            return null;
        }
        public static string PostUnToken(string url, string body)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            //request.AddQueryParameter("id","")  添加url的参数(AddUrlSegment)
            //request.AddHeader("Authorization",Token);//添加请求头参数
            // request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddJsonBody(body);
            //request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", user, ParameterType.RequestBody);
            var response = restClient.Post(request);
            //var response = await restClient.ExecutePostTaskAsync<string>(request); 自动序列化
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            return null;
        }
        public static string GetUnToken(string url)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            var response = restClient.Get(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                return content;
            }
            return null;
        }
        public static async Task<string> GetUnTokenAsync(string url)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            var response =await restClient.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                return content;
            }
            return null;
        }
        public static string GetToken(string url)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {Token}");//添加请求头参数
            var response = restClient.Get(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                return content;
            }
            return null;
        }
        public static async Task<string> GetTokenAsync(string url)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {Token}");//添加请求头参数
            var response = await restClient.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                return content;
            }
            return null;
        }
        public static string DeleteToken(string url)
        {
            string completeUrl = $"{BaseAddress}{url}";
            RestClient restClient = Instance(completeUrl);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {Token}");//添加请求头参数
            var response = restClient.Delete(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                return content;
            }
            return null;
        }
        /// <summary>
        /// 获取拼接Uri
        /// </summary>
        /// <param name="prefix">请求前缀地址</param>
        /// <param name="dic">查询参数字典</param>
        /// <returns>Uri</returns>
        public static string GetSpliceUrl(string prefix, Dictionary<string, string> dic)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in dic)
            {
                query[item.Key] = item.Value;
            }
            string queryString = query.ToString();
            var uri = prefix + (string.IsNullOrEmpty(queryString) ? "" : "?") + queryString;
            //进行解码成中文格式，再返回
            string result = HttpUtility.UrlDecode(uri, Encoding.GetEncoding("UTF-8"));
            Console.WriteLine(result);
            return result;
        }
    }

}
