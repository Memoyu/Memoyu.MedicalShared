/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：DicRecipeTypeModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/23 14:58:13
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

namespace MedicalShredApp.Models.Dics
{
    public class DicFrequencyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Count { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
