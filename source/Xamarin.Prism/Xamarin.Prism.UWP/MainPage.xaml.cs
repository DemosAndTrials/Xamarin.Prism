using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Prism.UWP.CustomViews;

namespace Xamarin.Prism.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Prism.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public static IUnityContainer Container;

        public void RegisterTypes(IUnityContainer container)
        {
            Container = container;
            container.RegisterType<LoginPopupRenderer>();
        }
    }

}
