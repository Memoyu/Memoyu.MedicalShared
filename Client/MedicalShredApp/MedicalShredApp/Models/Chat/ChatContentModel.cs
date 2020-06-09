/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ChatContentModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/27 21:24:51
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
    public class ChatContentModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public bool IsLatest { get; set; }
    }
}
