using System;
using System.Threading.Tasks;
using CloudMusic.Models;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Services;
using MedicalShredApp.ViewModels.News;
using MedicalShredApp.ViewModels.Profile;
using MedicalShredApp.ViewModels.Reserve;
using MedicalShredApp.ViewModels.TimeLine;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MedicalShredApp.Views;
using MedicalShredApp.Views.News;
using MedicalShredApp.Views.Profile;
using MedicalShredApp.Views.Reserve;
using MedicalShredApp.Views.TimeLine;
using Prism;
using Prism.Ioc;
using Prism.Logging;
using Prism.Unity;
namespace MedicalShredApp
{
    public partial class App : PrismApplication
    {
        public static Context Context;
        DebugLogger logger = new DebugLogger();
        public App() : this(null)
        {

        }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnStart()
        {
            await Task.Run(() =>//加载字典数据
            {
                var j = GlobalData.JobTypes;
                var b = GlobalData.BloodTypes;
                var p = GlobalData.Provinces;
                var r = GlobalData.RecipeTypes;
                var f = GlobalData.Frequencys;
            });
            var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            statusbar.SetLightTheme();
        }

        protected override void OnSleep()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<NewsPage, NewsViewModel>();
            containerRegistry.RegisterForNavigation<NewsDetailPage, NewsDetailViewModel>();
            containerRegistry.RegisterForNavigation<TimeLinePage, TimeLineViewModel>();
            containerRegistry.RegisterForNavigation<TimePointDetailPage, TimePointDetailViewModel>();
            containerRegistry.RegisterForNavigation<ReservePage, ReserveViewModel>();
            containerRegistry.RegisterForNavigation<DoctorChatPage, DoctorChatViewModel>();
            containerRegistry.RegisterForNavigation<SmartDiagnosisPage, SmartDiagnosisViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<RegisteredPage, RegisteredViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingViewModel>();
            containerRegistry.RegisterForNavigation<FocusPage, FocusViewModel>();
            containerRegistry.RegisterForNavigation<MyMessagePage, MyMessageViewModel>();
            containerRegistry.RegisterForNavigation<FocusPage>();
            containerRegistry.RegisterForNavigation<MyStartDoctorPage , MyStartDcotorViewModel>();
            containerRegistry.RegisterForNavigation<MyFocusNewsPage, MyFocusNewsViewModel>();
            containerRegistry.RegisterForNavigation<MyReservePage, MyReserveViewModel>();
            containerRegistry.RegisterForNavigation<MedicalRecordPage, MedicalRecordViewModel>();

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //Xamarin.Essentials.ExperimentalFeatures.Enable(Xamarin.Essentials.ExperimentalFeatures.ShareFileRequest);

            Context = new Context();
            //MainPage = new NavigationPage(new MasterDetailPage1());
            //MainPage = new ContentPage();
            try
            {
                System.Threading.Tasks.TaskScheduler.UnobservedTaskException += (sender, e) =>
                {
                    logger.Log(e.Exception.ToString(), Category.Exception, Priority.High);
                };

                //if ()
                //{
                //    await NavigationService.NavigateAsync("/NavigationPage/MusicHomePage?selectedTab=MusicDiscoverPage");

                //}
                //else
                //{
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(Views.MainPage)}");
                //}
            }
            catch (System.Exception e)
            {
                logger.Log(e.ToString(), Category.Exception, Priority.High);
            }
        }

        protected override void OnResume()
        {
        }
    }
}
