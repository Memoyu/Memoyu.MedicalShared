using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Reserve.Models;
using Xamarin.Forms;

namespace MedicalShredApp.CustomForms.Controls
{
    public partial class SidebarControl : ContentView
    {
        bool IsMenuOpen;
        public static readonly BindableProperty CurrentHospitalChangedCommandProperty = BindableProperty.Create(nameof(CurrentHospitalChangedCommand), typeof(ICommand), typeof(SidebarControl), null);
        public static readonly BindableProperty SearchTextChangedCommandProperty = BindableProperty.Create(nameof(SearchTextChangedCommand), typeof(ICommand), typeof(SidebarControl), null);
        public static readonly BindableProperty HospitalsProperty = BindableProperty.Create(nameof(Hospitals), typeof(IEnumerable<HospitalViewModel>), typeof(SidebarControl), null);
        public static readonly BindableProperty HospitalSelectedProperty = BindableProperty.Create(nameof(HospitalSelected), typeof(HospitalViewModel), typeof(SidebarControl), null, BindingMode.TwoWay, propertyChanged: CurrentItemChange);
        public IEnumerable<HospitalViewModel> Hospitals
        {
            get => (IEnumerable<HospitalViewModel>)GetValue(HospitalsProperty);
            set => SetValue(HospitalsProperty, value);
        }
        public ICommand SearchTextChangedCommand
        {
            get => (ICommand)GetValue(SearchTextChangedCommandProperty);
            set => SetValue(SearchTextChangedCommandProperty, value);
        }
        public ICommand CurrentHospitalChangedCommand
        {
            get => (ICommand)GetValue(CurrentHospitalChangedCommandProperty);
            set => SetValue(CurrentHospitalChangedCommandProperty, value);
        }
        public HospitalViewModel HospitalSelected
        {
            get => (HospitalViewModel)GetValue(HospitalSelectedProperty);
            set => SetValue(HospitalSelectedProperty, value);
        }

        static void CurrentItemChange(object bindable, object oldValue, object newValue)
        {
            var control = (SidebarControl)bindable;
            var hospitals = control.FindByName("HospitalContainer") as FlexLayout;
            foreach (StackLayout stackLayout in hospitals.Children)
            {
                var label = stackLayout.FindByName<Label>("HospitalTitle");
                if (((HospitalViewModel)newValue).HosName == label.Text)
                {
                    control.MoveActiveIndicator(stackLayout);
                }
            }
        }

        public SidebarControl()
        {
            InitializeComponent();
        }

        void Hospital_Clicked(object sender, EventArgs e)
        {
            var label = ((StackLayout)sender).FindByName<Label>("HospitalTitle");
            HospitalSelected = Hospitals.FirstOrDefault(c => c.HosName == label.Text);
            if (CurrentHospitalChangedCommand != null)
                if (CurrentHospitalChangedCommand.CanExecute(HospitalSelected))
                    CurrentHospitalChangedCommand.Execute(HospitalSelected);
            if (IsMenuOpen)
                Toggle_Menu(null , EventArgs.Empty);
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = Search.Text.Trim();
            if (SearchTextChangedCommand == null) return;
            if (SearchTextChangedCommand.CanExecute(input))
                SearchTextChangedCommand.Execute(input);
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //Fix for Indicator
            foreach (StackLayout stackLayout in HospitalContainer.Children)
            {
                var label = stackLayout.FindByName<Label>("HospitalTitle");
                if (HospitalSelected.HosName == label.Text)
                {
                    MoveActiveIndicator(stackLayout);
                }
            }
        }

        void MoveActiveIndicator(StackLayout target)
        {
            var parent = target.Parent as FlexLayout;
            foreach (Element parentChild in parent.Children)
            {
                ((StackLayout) parentChild).BackgroundColor = this.BackgroundColor;
            }
            target.BackgroundColor =(Color)App.Current.Resources["Primary"];
        }
        
        void  Toggle_Menu(System.Object sender, System.EventArgs e)
        {
            Animation animateSection;
            animateSection = IsMenuOpen ? new Animation(d => menuContainer.WidthRequest = d, 300, 80) : new Animation(d => menuContainer.WidthRequest = d, 80, 300);
            animateSection.Commit(menuContainer, "MoreLikeSectionToggleAnimation", 16, 450, Easing.SpringIn);
            IsMenuOpen = !IsMenuOpen;
        }

        //void SwipeGestureRecognizer_Swiped(System.Object sender, Xamarin.Forms.SwipedEventArgs e)
        //{
        //    Animation animateSection;
        //    animateSection = IsMenuOpen ? new Animation(d => menuContainer.WidthRequest = d, 300, 80) : new Animation(d => menuContainer.WidthRequest = d, 80, 300);
        //    animateSection.Commit(menuContainer, "MoreLikeSectionToggleAnimation", 16, 450, Easing.SpringIn);
        //    IsMenuOpen = !IsMenuOpen;
        //}
       
    }
}
