using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalShredApp.Models;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Reserve.Models;
using Prism.Commands;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.CustomForms.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorListControl : ContentView
    {
        private double _lastScrollY;
        //public Func<bool> ScrollBotFunc;
        public static readonly BindableProperty GoToDetailCommandProperty = BindableProperty.Create(nameof(GoToDetailCommand), typeof(DelegateCommand<DoctorViewModel>), typeof(DoctorListControl));
        public static readonly BindableProperty SearchDoctorCommandProperty = BindableProperty.Create(nameof(SearchDoctorCommand), typeof(DelegateCommand<string>), typeof(DoctorListControl), null);
        public static readonly BindableProperty ReserveRecordClickCommandProperty = BindableProperty.Create(nameof(ReserveRecordClickCommand), typeof(ICommand), typeof(DoctorListControl), null);
        public static readonly BindableProperty SmartDiagnosisClickCommandProperty = BindableProperty.Create(nameof(SmartDiagnosisClickCommand), typeof(ICommand), typeof(DoctorListControl), null);
        public static readonly BindableProperty CurrentHospitalProperty = BindableProperty.Create(nameof(CurrentHospital), typeof(HospitalViewModel), typeof(DoctorListControl), new HospitalViewModel());
        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(DoctorListControl), false);
        public static readonly BindableProperty IsUpLoadMoreProperty = BindableProperty.Create(nameof(IsUpLoadMore), typeof(bool), typeof(DoctorListControl), true);
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(ICommand), typeof(DoctorListControl), null);
        public static readonly BindableProperty DoctorsProperty = BindableProperty.Create(nameof(Doctors), typeof(IEnumerable<DoctorViewModel>), typeof(DoctorListControl), null);

        public HospitalViewModel CurrentHospital
        {
            get => (HospitalViewModel)GetValue(CurrentHospitalProperty);
            set => SetValue(CurrentHospitalProperty, value);
        }
        public IEnumerable<DoctorViewModel> Doctors
        {
            get => (IEnumerable<DoctorViewModel>)GetValue(DoctorsProperty);
            set => SetValue(DoctorsProperty, value);
        }
        public ICommand SearchDoctorCommand
        {
            get => (ICommand)GetValue(SearchDoctorCommandProperty);
            set => SetValue(SearchDoctorCommandProperty, value);
        }
        public ICommand ReserveRecordClickCommand
        {
            get => (ICommand)GetValue(ReserveRecordClickCommandProperty);
            set => SetValue(ReserveRecordClickCommandProperty, value);
        }
        public ICommand SmartDiagnosisClickCommand
        {
            get => (ICommand)GetValue(SmartDiagnosisClickCommandProperty);
            set => SetValue(SmartDiagnosisClickCommandProperty, value);
        }
        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }
        public bool IsUpLoadMore
        {
            get => (bool)GetValue(IsUpLoadMoreProperty);
            set => SetValue(IsUpLoadMoreProperty, value);
        }
        public ICommand LoadMoreCommand
        {
            get => (ICommand)GetValue(LoadMoreCommandProperty);
            set => SetValue(LoadMoreCommandProperty, value);
        }
        public DelegateCommand<DoctorViewModel> GoToDetailCommand
        {
            get => (DelegateCommand<DoctorViewModel>)GetValue(GoToDetailCommandProperty);
            set => SetValue(GoToDetailCommandProperty, value);
        }
        public DoctorListControl()
        {
            InitializeComponent();
        }
        private void ScrollView_OnScrolled(object sender, ScrolledEventArgs e)
        {
            if (!IsUpLoadMore) return;
            bool isUp = false;
            ScrollView scrollView = sender as ScrollView;
            var currentY = e.ScrollY;//当前高度
            var totalH = scrollView.ContentSize.Height;//
            if (currentY < _lastScrollY)
            {
                isUp = true;
            }
            _lastScrollY = currentY;
            //Console.WriteLine("Current Scroll ==========" + e.ScrollY);
            //Console.WriteLine(scrollView.ContentSize.Height);

            // After testing I found the bottom's offset is about 600 less than the scroll view's content size's height,
            // you can adjust this as you want
            if (IsBusy) return;
            if (!isUp && totalH - currentY <= 900 && totalH - currentY >= 850)
            {
                //Console.WriteLine("加载更多");
                LoadMoreCommand.Execute(null);
                // MyEntry.IsVisible = true;
            }
        }
        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var input = Search.Text?.Trim();
            if (SearchDoctorCommand == null) return;
            if (SearchDoctorCommand.CanExecute(input))
                SearchDoctorCommand.Execute(input);
        }
    }
}