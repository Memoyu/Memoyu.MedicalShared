using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Reserve
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorChatPage : ContentPage
    {
        public DoctorChatPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }

        private void BindableObject_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ChatContentList.ItemsSource != null)
            {
                var v = ChatContentList.ItemsSource.Cast<object>().LastOrDefault();
                ChatContentList.ScrollTo(v, ScrollToPosition.End, true);
            }
        }
    }
}