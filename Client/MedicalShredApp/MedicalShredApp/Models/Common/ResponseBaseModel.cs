/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ResponseBaseModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/13 13:44:40
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

namespace MedicalShredApp.Models.Common
{
    public class ResponseBaseModel
    {
        public int code { get; set; } = -1;
        public string msg { get; set; }
        public object data { get; set; }
    }
}
