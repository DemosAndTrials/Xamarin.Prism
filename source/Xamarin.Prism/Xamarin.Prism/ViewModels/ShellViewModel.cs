using Prism.Mvvm;
using Prism.Navigation;

namespace Xamarin.Prism.ViewModels
{
    public class ShellViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            _navigationService.NavigateAsync("MainView");
        }
    }
}
