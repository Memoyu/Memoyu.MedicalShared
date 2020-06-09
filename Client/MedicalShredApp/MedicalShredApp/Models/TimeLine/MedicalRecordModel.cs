/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Models.TimeLine
*   文件名称 ：MedicalRecordModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-22 23:20:04
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

namespace MedicalShredApp.Models.TimeLine
{
    public class MedicalRecordModel
    {
        public int Id { get; set; }
        public string HosName { get; set; }
        public string Pid { get; set; }
        public DateTime AdviceDtime { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public bool FirstVisit { get; set; }
        public string ChiefComplaint { get; set; }
        public string HistoryPresentIllness { get; set; }
        public string HistoryDisease { get; set; }
        public string AllergyHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string Temperature { get; set; }
        public string SystolicPressure { get; set; }
        public string DiastolicPressure { get; set; }
        public string Pulse { get; set; }
        public string Breathing { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string PhysicalExamination { get; set; }
        public string SpecialistSituation { get; set; }
        public string SupplementaryExamination { get; set; }
        public string PreliminaryDiagnosis { get; set; }
        public string Handle { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
