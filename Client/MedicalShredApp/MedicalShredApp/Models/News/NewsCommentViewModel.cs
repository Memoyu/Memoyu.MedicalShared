/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：ViewModels.News
*   文件名称 ：NewsCommentViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-02-29 8:29:37
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
    public class NewsCommentModel
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
