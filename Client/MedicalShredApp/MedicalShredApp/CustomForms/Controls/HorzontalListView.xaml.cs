using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.CustomForms.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorzontalListView : ContentView
    {

        public static readonly BindableProperty YearsProperty = BindableProperty.Create(nameof(Years), typeof(IEnumerable<string>), typeof(HorzontalListView), null);
        public static readonly BindableProperty YearSelectedItemProperty = BindableProperty.Create(nameof(YearSelectedItem), typeof(string), typeof(HorzontalListView), null, BindingMode.TwoWay, propertyChanged: CurrentItemChange);
        public static readonly BindableProperty SelectedItemCommandProperty = BindableProperty.Create(nameof(SelectedItemCommand), typeof(ICommand), typeof(HorzontalListView), null);

        public IEnumerable<string> Years
        {
            get => (IEnumerable<string>)GetValue(YearsProperty);
            set => SetValue(YearsProperty, value);
        }
        public ICommand SelectedItemCommand
        {
            get => (ICommand)GetValue(SelectedItemCommandProperty);
            set => SetValue(SelectedItemCommandProperty, value);
        }
        public string YearSelectedItem
        {
            get => (string)GetValue(YearSelectedItemProperty);
            set => SetValue(YearSelectedItemProperty, value);
        }
        private static void CurrentItemChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (HorzontalListView)bindable;
            var years = control.FindByName("YearEl") as StackLayout;
            foreach (var view in years.Children)
            {
                var btn = (Button)view;
                VisualStateManager.GoToState(btn, newvalue.ToString().Equals(btn.Text) ? "YearSelected" : "YearUnSelected");
            }

        }
        public HorzontalListView()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            YearSelectedItem = Years.FirstOrDefault(c => c == btn.Text);
            if (SelectedItemCommand != null)
                if (SelectedItemCommand.CanExecute(YearSelectedItem))
                    SelectedItemCommand.Execute(YearSelectedItem);
            foreach (View child in YearEl.Children)
            {
                var childBtn = (Button)child;
                VisualStateManager.GoToState(childBtn, "YearUnSelected");
            }
            VisualStateManager.GoToState(btn, "YearSelected");
        }
    }
}