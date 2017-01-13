using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Prism.Services;

namespace Xamarin.Prism.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authentication;

        public DelegateCommand<string> LoginCommand { get; private set; }

        public LoginViewModel(INavigationService navigationService, IAuthenticationService authentication)
        {
            _navigationService = navigationService;
            _authentication = authentication;
            LoginCommand = new DelegateCommand<string>(Login);
        }

        private void Login(string org)
        {
            // start login process
            _authentication.OrgType = org;
            _navigationService.NavigateAsync("LoginPopupView");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (_authentication.UserAccount != null)
            {
                _navigationService.NavigateAsync("ShellView/RootView/MainView", animated: false);
            }
        }
    }
}
