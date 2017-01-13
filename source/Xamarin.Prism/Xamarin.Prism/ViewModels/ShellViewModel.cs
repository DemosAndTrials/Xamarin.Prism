using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Xamarin.Prism.ViewModels
{
    public class ShellViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand<string> NavigationCommand { get; private set; }

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationCommand = new DelegateCommand<string>(MenuNavigation);
        }

        private void MenuNavigation(string details)
        {
            if ("Home".Equals(details))
            {
                _navigationService.NavigateAsync("ShellView/MainView");
            }
            else if ("Agenda".Equals(details))
            {
                _navigationService.NavigateAsync("RootView/TabMainPage");
            }
            else if ("accounts".Equals(details))
            {

            }
            else if ("tasks".Equals(details))
            {

            }
            else if ("Product".Equals(details))
            {

            }
            else if ("Profile".Equals(details))
            {
                _navigationService.NavigateAsync("ShellView/RootView/ProfileView");
            }
            else if ("Settings".Equals(details))
            {

            }
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //_navigationService.NavigateAsync("NavigationPage/MainView");
        }
    }
}
