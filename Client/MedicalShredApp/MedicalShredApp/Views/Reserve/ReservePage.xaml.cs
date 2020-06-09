using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.ViewModels.Reserve;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Reserve
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservePage : ContentPage
    {
        private bool _isBackstage = false;
        private static ReserveViewModel _reserveViewModel;
        public ReservePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_isBackstage) return;
            AssignmentData();

        }

        private async void AssignmentData()
        {
            var vm = (ReserveViewModel)this.BindingContext;
            _reserveViewModel = vm;
            var hospitals = await Api.GetHospitals();
            vm.Hospitals = (IList<HospitalViewModel>)hospitals;
            var firstHos = hospitals.FirstOrDefault();
            vm.CurrentHospital = firstHos;
            vm.CurrentHospitalChangedCommand.Execute(firstHos);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isBackstage = true;
        }

        #region Method

        private async void DoctorListControl_DoctorAdded(Object sender, EventArgs e)
        {
            //限制性判断，判断是否可以预约，


            //var layout= DoctorScroll.FindByName<StackLayout>("StackLayout");
            //var button = layout.FindByName<Button>("CurrentBtn");
            //var image = new FFImageLoading.Forms.CachedImage
            //{
            //    Source = (sender as DoctorViewModel).Photo,
            //    TranslationY = layout.Y + 60,
            //    WidthRequest = 70,
            //    HeightRequest = 70,
            //    TranslationX = layout.X+100,
            //    DownsampleToViewSize = true,
            //    Scale = 0
            //};
            //mainContainer.Children.Add(image);
            //await image.ScaleTo(1, 200, Easing.CubicOut);
            //await Task.WhenAll(
            //    image.TranslateTo(layout.X +300, layout.Y, 300, Easing.CubicIn), 
            //    image.ScaleTo(0, 300, Easing.CubicIn),
            //    button.ScaleTo(1.2, 200, Easing.CubicIn)
            //);
            //await button.ScaleTo(1, 200, Easing.CubicIn);
            //mainContainer.Children.Remove(image);

        }

        #endregion
    }
}