using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms.Xaml;
using Xamarin.Prism.Services;
using Xamarin.Prism.ViewModels;
using Xamarin.Prism.Views;
using TabA = Xamarin.Prism.Views.TabA;
using TabB = Xamarin.Prism.Views.TabB;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("LoginView", animated: false);
            //NavigationService.NavigateAsync("ShellView/DetailView/MainView", animated: false);
        }

        protected override void RegisterTypes()
        {
            // test here
            Container.RegisterTypeForNavigation<DetailView>();
            // end test

            Container.RegisterTypeForNavigation<TabMainPage>();
            Container.RegisterTypeForNavigation<TabA, TabViewModel>();
            Container.RegisterTypeForNavigation<TabB, TabViewModel>();
            Container.RegisterTypeForNavigation<TabC, TabViewModel>();

            Container.RegisterTypeForNavigation<DetailView>();
            Container.RegisterTypeForNavigation<ShellView>();
            Container.RegisterTypeForNavigation<MainView>();
            Container.RegisterTypeForNavigation<LoginView>();
            Container.RegisterTypeForNavigation<LoginPopupView>();
            Container.RegisterTypeForNavigation<ProfileView>();
            Container.RegisterTypeForNavigation<CameraView>();
            Container.RegisterTypeForNavigation<BarcodeScanView>();

            // singleton
            Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAuthenticationService, AuthenticationService>(new ContainerControlledLifetimeManager());
        }
    }
}
