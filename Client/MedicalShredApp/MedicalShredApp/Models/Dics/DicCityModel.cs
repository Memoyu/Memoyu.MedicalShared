/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：DicProvinceModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/13 22:26:51
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;

namespace MedicalShredApp.Models.Dics
{
    public class DicCityModel
    {

        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public int SortId { get; set; }
        public bool IsEnable { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public override string ToString() => Name;
    }
}
