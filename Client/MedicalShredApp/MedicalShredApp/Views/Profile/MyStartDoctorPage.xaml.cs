using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.Models.Profile;
using MedicalShredApp.ViewModels.Profile;
using MedicalShredApp.ViewModels.Reserve;
using MedicalShredApp.Views.Reserve;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyStartDoctorPage : ContentPage
    {
        public MyStartDoctorPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Page> pages = Navigation.NavigationStack.ToList();
            if (pages.Count > 2) return;
            var vm = (MyStartDcotorViewModel)BindingContext;
            vm.RefreshCommand.Execute(null);
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            var m = lv.SelectedItem as FollowDoctorDetailModel;
            var vm = (MyStartDcotorViewModel)BindingContext;
            vm.DoctorDetailCommand.Execute(m);
            lv.SelectedItem = null;

        }
    }
}