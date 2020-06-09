/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ParseResponseJsonContent
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/13 13:43:43
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using MedicalShredApp.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedicalShredApp.Action.Api
{
    public class ParseResponseJsonContent
    {
        public static T ParseObj<T>(string content, out string msg) where T : new()
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<ResponseBaseModel>(content);
                    if (obj.code == 0)
                    {
                        if (!string.IsNullOrEmpty(obj.data.ToString()))
                        {
                            T temp = JsonConvert.DeserializeObject<T>(obj.data.ToString());
                            msg = obj.msg;
                            return temp;
                        }
                    }
                    msg = obj.msg;
                    return default;
                }
                catch (Exception ex)
                {
                    //logger.ErrorLog($"JSON->Model数据解析出错！", ex);
                    throw new Exception($"JSON->Model数据解析出错！", ex);
                }
            }
            msg = "响应返回数据为空！";
            return default;
        }
        public static bool ParseBool(string content, out string msg) 
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<ResponseBaseModel>(content);
                    if (obj.code == 0)
                    {
                        msg = null;
                        return true;
                    }
                    msg = obj.msg;
                    return false;
                }
                catch (Exception ex)
                {
                    //logger.ErrorLog($"JSON->Model数据解析出错！", ex);
                    throw new Exception($"JSON->Bool数据解析出错！", ex);
                }
            }
            msg = "响应返回数据为空！";
            return false;
        }
        public static IEnumerable<T> ParseList<T>(string content, out string msg) where T : new()
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<ResponseBaseModel>(content);
                    if (obj.code == 0)
                    {
                        if (!string.IsNullOrEmpty(obj.data.ToString()))
                        {

                            var temp = JsonConvert.DeserializeObject<List<T>>(obj.data.ToString());
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
        }
        public static ObservableCollection<T> ParseObCollection<T>(string content, out string msg) where T : new()
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<ResponseBaseModel>(content);
                    if (obj.code == 0)
                    {
                        if (!string.IsNullOrEmpty(obj.data.ToString()))
                        {

                            var temp = JsonConvert.DeserializeObject<ObservableCollection<T>>(obj.data.ToString());
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
        }
    }
}
