/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ChatMainModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/30 11:58:03
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
    public class ChatMainModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AnotherId { get; set; }
    }
}
