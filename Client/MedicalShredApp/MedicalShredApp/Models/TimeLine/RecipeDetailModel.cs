/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Models.TimeLine
*   文件名称 ：RecipeDetailModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-22 23:19:40
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
    public class RecipeDetailModel
    {
        public int Id { get; set; }
        public string RegisteredNo { get; set; }
        public string RecipesNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Usages { get; set; }
        public int Frequency { get; set; }
        public int ExeDays { get; set; }
        public string Dosage { get; set; }
        public string DosageUnit { get; set; }
        public string OnceDosage { get; set; }
        public string OnceDosageUnit { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
        public decimal Money { get; set; }
        public int BelongType { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
