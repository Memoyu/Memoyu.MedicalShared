/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Models.Chat
*   文件名称 ：ChatListModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-05-10 15:50:11
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

namespace MedicalShredApp.Models.Chat
{
    public class ChatListModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public Guid UserId { get; set; }
        public Guid AnotherId { get; set; }
        public bool IsOnline { get; set; }
        public int Unread { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LatestTime { get; set; }
    }
}
