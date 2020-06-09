using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Annotations;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Dics;
using MedicalShredApp.ViewModels.Profile;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisteredPage : ContentPage
    {
        private PopupPage _loginPopupPage;

        #region Field



        #endregion

        #region Prop


        #endregion
        public RegisteredPage()
        {
            Task.Run(GetBaseData);
        }
        public RegisteredPage(PopupPage loginPopupPage)
        {
            InitializeComponent();
            _loginPopupPage = loginPopupPage;
            Task.Run(GetBaseData);

        }
        private async void GetBaseData()
        {
            //if (_loginPopupPage != null)
            //    await PopupNavigation.Instance.RemovePageAsync(_loginPopupPage, true);

            Blood.ItemsSource = (IList)GlobalData.BloodTypes;
            Job.ItemsSource = (IList)GlobalData.JobTypes;
            Province.ItemsSource = (IList)GlobalData.Provinces;
        }
    }
}