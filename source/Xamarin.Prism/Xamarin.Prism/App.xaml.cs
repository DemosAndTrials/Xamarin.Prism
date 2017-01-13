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

            NavigationService.NavigateAsync("LoginView");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<TabMainPage>();
            //Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<TabA, TabViewModel>();
            Container.RegisterTypeForNavigation<TabB, TabViewModel>();
            Container.RegisterTypeForNavigation<TabC, TabViewModel>();

            Container.RegisterTypeForNavigation<RootView>();
            Container.RegisterTypeForNavigation<ShellView>();
            Container.RegisterTypeForNavigation<MainView>();
            Container.RegisterTypeForNavigation<LoginView>();
            Container.RegisterTypeForNavigation<LoginPopupView>();
            Container.RegisterTypeForNavigation<ProfileView>();

            // singleton
            Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAuthenticationService, AuthenticationService>(new ContainerControlledLifetimeManager());

        }
    }
}
