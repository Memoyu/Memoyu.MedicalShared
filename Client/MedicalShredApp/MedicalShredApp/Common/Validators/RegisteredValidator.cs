/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：RegisteredValidator
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/14 13:17:46
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
using FluentValidation;
using MedicalShredApp.Models.Profile;

namespace MedicalShredApp.Common.Validators
{
    public class RegisteredValidator : AbstractValidator<UserInfoModel>
    {
        public RegisteredValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("请输入用户名")
                .MaximumLength(20).WithMessage("用户名最大长度在20个字符");
            RuleFor(x => x.RealName).NotEmpty().WithMessage("请输入真实姓名")
                .Length(2 , 20).WithMessage("真实姓名长度在2到20个字符之间");
            RuleFor(x => x.TelNo).NotEmpty().WithMessage("请输电话号码")
                .Length(11).WithMessage("身份证号为11位");
            RuleFor(x => x.IdNo).NotEmpty().WithMessage("请输入身份证号")
                .Length(18).WithMessage("身份证号为18位");
            RuleFor(x => x.Password).NotEmpty().WithMessage("请输入密码");
            RuleFor(x => x.BloodCode).NotEmpty().WithMessage("请选择血型");
            RuleFor(x => x.LxProvince).NotEmpty().WithMessage("请选择省份");
            RuleFor(x => x.LxCity).NotEmpty().WithMessage("请选择市");
            RuleFor(x => x.LxCounty).NotEmpty().WithMessage("请选择区、镇");
            RuleFor(x => x.JobCode).NotEmpty().WithMessage("请选择职业");
            RuleFor(x => x.Email).NotEmpty().WithMessage("请输入邮箱");
        }
    }
}
