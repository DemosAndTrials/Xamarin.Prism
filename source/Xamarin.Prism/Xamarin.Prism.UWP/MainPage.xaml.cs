using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Prism.Data.Services;

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
        public void RegisterTypes(IUnityContainer container)
        {
            AccountStoreFactory.Create = () => new AccountStoreUWP();
        }
    }

}
