/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：FollowDoctorDetailModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/13 20:42:49
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

namespace MedicalShredApp.Models.Profile
{
    public class FollowDoctorDetailModel
    {
        public Guid Id { get; set; }
        public string HosName { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string Photo { get; set; }
        public DateTime FollowDate { get; set; }
    }
}
