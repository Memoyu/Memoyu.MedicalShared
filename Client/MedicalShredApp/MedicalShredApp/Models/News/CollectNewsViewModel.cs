/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：CollectNewsViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/5/16 0:02:17
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

namespace MedicalShredApp.Models.News
{
    public class CollectNewsViewModel
    {
        public Guid Uid { get; set; }
        public int NewsId { get; set; }
        public bool IsCollect { get; set; }
        public DateTime CollectDate { get; set; }
    }
}
