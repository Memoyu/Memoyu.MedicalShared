using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.ViewModels.Reserve;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyReservePage : ContentPage
    {
        public MyReservePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Page> pages = Navigation.NavigationStack.ToList();
            if (pages.Count > 2) return;
            var vm = (MyReserveViewModel)BindingContext;
            vm.RefreshCommand.Execute(null);
        }
        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            var m = lv.SelectedItem as ReserveDoctorViewModel;
            var vm = (MyReserveViewModel)BindingContext;
            vm.ChatDoctorCommand.Execute(m);
            lv.SelectedItem = null;

        }
    }
}