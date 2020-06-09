/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ReserveDoctorViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/15 20:32:17
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
    public class ReserveDoctorViewModel
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string HosName { get; set; }
        public string Department { get; set; }
        public bool IsDelete { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ReserveDate { get; set; }
    }
}
