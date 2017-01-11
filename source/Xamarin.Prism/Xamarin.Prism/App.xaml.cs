using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Prism.ViewModels;
using Xamarin.Prism.Views;
using MainPage = Xamarin.Prism.Views.MainPage;
using TabA = Xamarin.Prism.Views.TabA;
using TabB = Xamarin.Prism.Views.TabB;

namespace Xamarin.Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Forms.NavigationPage>();
            Container.RegisterTypeForNavigation<TabA, TabViewModel>();
            Container.RegisterTypeForNavigation<TabB, TabViewModel>();
            Container.RegisterTypeForNavigation<TabC, TabViewModel>();

            Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
        }
    }
}
