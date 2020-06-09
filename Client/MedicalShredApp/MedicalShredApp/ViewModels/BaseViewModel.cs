/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：MedicalShredApp.ViewModels
*   文件名称 ：BaseViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-04-14 22:15:34
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MedicalShredApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using DependencyService = Xamarin.Forms.DependencyService;

namespace MedicalShredApp.ViewModels
{
    public class BaseViewModel : BindableBase, INotifyPropertyChanged, INavigationAware, IDestructible
    {
        public System.DateTime? lastBackKeyDownTime;
        protected INavigationService NavigationService { get; private set; }
        bool isBusy = false;

        public BaseViewModel(INavigationService navigationService )
        {
            NavigationService = navigationService;
            GoBackCommand = new DelegateCommand(async () => await NavigationService.GoBackAsync());
        }
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value, "IsBusy");
        }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public bool BackKeyPressed()
        {
            if (!lastBackKeyDownTime.HasValue || System.DateTime.Now - lastBackKeyDownTime.Value > new System.TimeSpan(0, 0, 2))
            {
                lastBackKeyDownTime = System.DateTime.Now;
                Device.BeginInvokeOnMainThread(() => DependencyService.Get<IToast>().ShortAlert("再按一次退出"));
                return true;
            }
            else
            {
                return false;
            }
        }



        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
        public DelegateCommand GoBackCommand { get; private set; }
    }
}
