using Prism.Mvvm;
using Prism.Navigation;

namespace Xamarin.Prism.ViewModels
{
    public class LoginPopupViewModel : BindableBase, INavigationAware
    {
        public string NavigationParameter { get; set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            NavigationParameter = parameters["orgType"] as string;
        }
    }
}
