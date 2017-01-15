using Prism.Commands;
using Prism.Navigation;
using Xamarin.Prism.Services;
using Xamarin.Prism.ViewModels.Abstract;

namespace Xamarin.Prism.ViewModels
{
    public class LoginViewModel : ViewModelBase
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

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (await _authentication.IsAuthenticatedAsync())
            {
                await _navigationService.NavigateAsync("ShellView/DetailView/MainView", animated: false);
            }
        }
    }
}
