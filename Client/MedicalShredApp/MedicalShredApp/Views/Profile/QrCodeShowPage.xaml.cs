using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShredApp.Common.Tools;
using MedicalShredApp.Models.Common;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MedicalShredApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrCodeShowPage : PopupPage
    {
        public QrCodeShowPage()
        {
            InitializeComponent();
            GenerateQrCodeView();
        }

        private void GenerateQrCodeView()
        {
            ZXingBarcodeImageView image = ZxingHelper.GenerateQrCode(GlobalData.UserInfo.QrCode);
            Content.Children.Insert(0,image);
        }
    }
}