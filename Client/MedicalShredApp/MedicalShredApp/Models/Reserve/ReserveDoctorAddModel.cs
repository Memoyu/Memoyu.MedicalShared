/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ReserveDoctorAddModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/15 19:46:00
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
    public class ReserveDoctorAddModel
    {
        public Guid DoctorId { get; set; }
        public Guid Uid { get; set; }
        public DateTime ReserveDate { get; set; }
    }
}
