/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：NewsPageModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/15 13:45:44
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

namespace MedicalShredApp.Models.News
{
    public class NewsPageModel
    {
        public int Count { get; set; }
        public List<NewsModel> Data { get; set; }
    }
}
