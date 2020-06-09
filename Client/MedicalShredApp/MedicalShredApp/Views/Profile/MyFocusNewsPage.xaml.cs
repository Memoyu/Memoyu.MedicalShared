using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.ViewModels.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFocusNewsPage : ContentPage
    {
        public MyFocusNewsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (MyFocusNewsViewModel)this.BindingContext;
            vm.RefreshCommand.Execute(null);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }
    }
}