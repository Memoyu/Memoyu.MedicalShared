/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels.Profile
*   文件名称 ：RegisteredViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-12 19:59:03
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FluentValidation;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Common.Tools;
using MedicalShredApp.Common.Validators;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Dics;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.Services;
using MedicalShredApp.Views;
using MedicalShredApp.Views.Profile;
using Plugin.InputKit.Shared.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MedicalShredApp.ViewModels.Profile
{
    public class RegisteredViewModel : BaseViewModel
    {


        #region Field

        private readonly IValidator _validator;

        private DicProvinceModel _provinceSelectedItem;
        private DicCityModel _citySelectedItem;
        private DicAreaModel _areaSelectedItem;
        private DicJobModel _jobSelectedItem;
        private DicBloodTypeModel _bloodSelectedItem;
        private IList<DicCityModel> _cites;
        private IList<DicAreaModel> _areas;
        private string _userName;
        private string _realName;
        private string _password;
        private string _passwordAgain;
        private string _telNo;
        private string _email;
        private string _idNo;
        private string _birthday;
        private bool _sex = true;


        #endregion

        #region Prop
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value, "UserName");
        }
        public string RealName
        {
            get => _realName;
            set => SetProperty(ref _realName, value, "RealName");
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, "Password");
        }
        public string PasswordAgain
        {
            get => _passwordAgain;
            set => SetProperty(ref _passwordAgain, value, "PasswordAgain");
        }
        public string TelNo
        {
            get => _telNo;
            set => SetProperty(ref _telNo, value, "TelNo");
        }
        public string IdNo
        {
            get => _idNo;
            set => SetProperty(ref _idNo, value, "IdNo");
        }
        public bool Sex
        {
            get => _sex;
            set => SetProperty(ref _sex, value, "Sex");
        }
        public string Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value, "Birthday");
        }
        public DicBloodTypeModel BloodSelectedItem
        {
            get => _bloodSelectedItem;
            set => SetProperty(ref _bloodSelectedItem, value, "BloodSelectedItem");
        }

        public DicProvinceModel ProvinceSelectedItem
        {
            get => _provinceSelectedItem;
            set
            {
                SetProperty(ref _provinceSelectedItem, value, "ProvinceSelectedItem");
                int? id = GlobalData.Provinces.FirstOrDefault(p => p.Name.Equals(_provinceSelectedItem.ToString()))?.Id;
                Cites = (IList<DicCityModel>)Api.GetCites(id);
                CitySelectedItem = null;
                AreaSelectedItem = null;
            }
        }
        public DicCityModel CitySelectedItem
        {
            get => _citySelectedItem;
            set
            {
                //_citySelectedItem = value;

                SetProperty(ref _citySelectedItem, value, "CitySelectedItem");
                if (value == null) return;
                int? id = Cites.FirstOrDefault(p => p.Name.Equals(_citySelectedItem.ToString()))?.Id;
                Areas = (IList<DicAreaModel>)Api.GetAreas(id);
                AreaSelectedItem = null;
            }
        }
        public DicAreaModel AreaSelectedItem
        {
            get => _areaSelectedItem;
            set => SetProperty(ref _areaSelectedItem, value, "AreaSelectedItem");
        }
        public DicJobModel JobSelectedItem
        {
            get => _jobSelectedItem;
            set => SetProperty(ref _jobSelectedItem, value, "JobSelectedItem");
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, "Email");
        }
        public IList<DicCityModel> Cites
        {
            get => _cites;
            set => SetProperty(ref _cites, value, "Cites");
        }
        public IList<DicAreaModel> Areas
        {
            get => _areas;
            set => SetProperty(ref _areas, value, "Areas");

        }
        public ICommand SexSelected { get; private set; }
        public ICommand RegisteredClickCommand { get; private set; }

        #endregion

        #region Method
        public RegisteredViewModel(INavigationService navigationService) : base(navigationService)
        {
            _validator = new RegisteredValidator();
            RegisteredClickCommand = new DelegateCommand(RegisteredClick);
        }
        /// <summary>
        /// 注册
        /// </summary>
        private void RegisteredClick()
        {

            UserInfoModel userInfo = new UserInfoModel
            {
                UserName = UserName,
                RealName = RealName,
                Password = string.IsNullOrWhiteSpace(Password) ? null : MD5Helper.GetMd5_32(Password),
                Birthday = DateTime.Parse(Birthday),
                BloodCode = BloodSelectedItem?.Id,
                LxProvince = ProvinceSelectedItem?.Name,
                LxCity = CitySelectedItem?.Name,
                LxCounty = AreaSelectedItem?.Name,
                JobCode = JobSelectedItem?.Id,
                Email = Email,
                IdNo = IdNo,
                TelNo = TelNo,
                SexCode = Sex ? 1 : 2
            };

            if (PasswordAgain == null || !PasswordAgain.Equals(Password))
            {
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("输入两次密码不一致，请确认！"));
                return;
            }

            string validateMsg = null;
            var validationResult = _validator.Validate(userInfo);
            if (validationResult.IsValid)
            {
                UserInfoModel info = Api.Registered(userInfo);
                if (info == null) return;
                var param = new NavigationParameters();
                param.Add("UserInfo", info);
                Device.BeginInvokeOnMainThread(async () => await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}?selectedTab={nameof(ProfilePage)}", param));
            }
            else
            {
                validateMsg = validationResult.Errors[0].ErrorMessage;
            }
            Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert(validateMsg));

        }

        #endregion
    }
}
