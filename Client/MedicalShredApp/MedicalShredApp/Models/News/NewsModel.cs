/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：NewsModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/11 9:38:47
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;

namespace MedicalShredApp.Models.News
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subhead { get; set; }
        public string Content { get; set; }
        public int ColumnId { get; set; }
        public DateTime DateTime { get; set; }
        public string Url { get; set; }
        public string Sender { get; set; }
        public string Ip { get; set; }
        public int Hits { get; set; }
        public bool IsTop { get; set; }
        public bool IsCloseComment { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
