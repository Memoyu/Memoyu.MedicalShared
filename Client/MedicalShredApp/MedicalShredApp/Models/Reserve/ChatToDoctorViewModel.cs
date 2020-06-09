/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Models.Reserve
*   文件名称 ：ChatToDoctorViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-05-10 17:42:55
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

namespace MedicalShredApp.Models.Reserve
{
    public class ChatToDoctorViewModel
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
