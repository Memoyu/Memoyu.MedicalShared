using System.Collections.Generic;
using System.Linq;
using MedicalShredApp.Models.News;
using MedicalShredApp.ViewModels.News;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        private bool _isBackstage = false;

        public NewsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_isBackstage) return;
            List<Page> pages = Navigation.NavigationStack.ToList();
            if (pages.Count > 1) return;
            var vm = (NewsViewModel)this.BindingContext;
            vm.RefreshCommand.Execute(null);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isBackstage = true;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            //var m = lv.SelectedItem as NewsModel;
            //var detailPage = new NewsDetailPage { BackgroundColor = Color.White };
            //detailPage.BindingContext = new NewsDetailViewModel(m);
            //Navigation.PushAsync(detailPage);
            lv.SelectedItem = null;
        }
    }
}