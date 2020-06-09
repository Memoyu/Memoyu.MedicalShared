/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：MUnauthorizedException
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/13 17:48:45
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;

namespace MedicalShredApp.Common.Exceptions
{
    public class MUnauthorizedException:ApplicationException
    {
        public MUnauthorizedException()
        {

        }
        public MUnauthorizedException(string message) : base(message)
        {

        }
        public MUnauthorizedException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
