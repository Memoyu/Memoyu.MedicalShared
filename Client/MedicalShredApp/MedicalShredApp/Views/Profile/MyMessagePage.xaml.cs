using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.Models.Chat;
using MedicalShredApp.ViewModels.Profile;
using MedicalShredApp.Views.Reserve;
using Prism.Navigation.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMessagePage : ContentPage
    {
        public MyMessagePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Page> pages = Navigation.NavigationStack.ToList();
            if (pages.Count > 2) return;
            var vm = (MyMessageViewModel)this.BindingContext;
            vm.RefreshCommand.Execute(null);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
          
        }
    }
}