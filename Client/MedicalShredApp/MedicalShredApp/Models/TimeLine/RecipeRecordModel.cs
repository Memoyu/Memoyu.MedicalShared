/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：RecipeRecordModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/11 1:04:31
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System;
using System.Drawing;

namespace MedicalShredApp.Models.TimeLine
{
    public class RecipeRecordModel
    {
        public int Id { get; set; }
        public int RecipeRecordNo { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HosName { get; set; }
        /// <summary>
        /// 对应医院患者id
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 患者名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 患者监护人名
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 科室名
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 医生名
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 就诊日期
        /// </summary>
        public DateTime VisitDate { get; set; }
        /// <summary>
        /// 发病日期
        /// </summary>
        public DateTime OccurDate { get; set; }
        /// <summary>
        /// 复诊标志
        /// </summary>
        public bool IsRepeat { get; set; }
        /// <summary>
        /// 血压值
        /// </summary>
        public string BloodPressure { get; set; }
        /// <summary>
        /// 血糖
        /// </summary>
        public string BloodSugar { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 临床症状
        /// </summary>
        public string ClinicalSymptoms { get; set; }
        public string Diagnosis { get; set; }
        /// <summary>
        /// 传染病标识
        /// </summary>
        public string DiseaseSigns { get; set; }
        /// <summary>
        /// 主要用药
        /// </summary>
        public string MainMed { get; set; }
        public bool State { get; set; }
        public DateTime CreateDatetime { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
