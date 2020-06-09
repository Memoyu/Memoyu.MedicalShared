/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：DoctorViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/20 13:40:37
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
    public class DoctorViewModel
    {
        public Guid Id { get; set; }
        public int HosCode { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public bool IsExpert { get; set; }
        public double ConsultationFee { get; set; }
        public int Follow { get; set; }
        public string Position { get; set; }
    }
}
