/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：FollowDoctorViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/19 15:03:24
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

namespace Models.Reserve
{
    public class FollowDoctorModel
    {
        public Guid Uid { get; set; }
        public Guid DoctorId { get; set; }
        public bool IsFollow { get; set; }
        public DateTime FollowDate { get; set; }
    }
}
