/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.Models.TimeLine
*   文件名称 ：RecipeRecordPreviewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-15 23:44:36
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MedicalShredApp.Models.TimeLine
{
    public class RecipeRecordPreviewModel
    {
        public int Id { get; set; }
        public string RegisteredNo { get; set; }
        public string DateTime { get; set; }
        public string Diagnosis { get; set; }
        public string ClinicalSymptoms { get; set; }
        public string Department { get; set; }
        public bool IsRepeat { get; set; }
    }
}
