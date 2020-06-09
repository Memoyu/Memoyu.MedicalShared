using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalShredApp.Views.Reserve
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorDetailPopupPage : PopupPage
    {
        public DoctorDetailPopupPage()
        {
            InitializeComponent();
        }
    }
}