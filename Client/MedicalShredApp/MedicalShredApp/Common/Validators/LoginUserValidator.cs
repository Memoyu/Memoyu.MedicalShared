/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：LoginUserValidator
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/14 11:05:36
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using FluentValidation;
using MedicalShredApp.Models.Profile;

namespace MedicalShredApp.Common.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginModel>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("请输入账号")
                .Length(2, 20).WithMessage("账号长度在2到20个字符之间");
            RuleFor(x => x.Password).NotEmpty().WithMessage("请输入密码");
        }
    }
}
