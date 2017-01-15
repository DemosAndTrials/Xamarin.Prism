using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Auth;
using Xamarin.Prism.Services;

namespace Xamarin.Prism.ViewModels
{
    public class LoginPopupViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        readonly IAuthenticationService _authentication;

        public LoginPopupViewModel(INavigationService navigationService, IAuthenticationService authentication)
        {
            _navigationService = navigationService;
            _authentication = authentication;
        }

        public string GetOrgType()
        {
            return _authentication.OrgType;
        }

        public async void FinishAuthentication(Account account)
        {
            // store user account
            await _authentication.SetAccountAsync(account);
            // navigate to main page
            await _navigationService.NavigateAsync("ShellView/DetailView/MainView", animated: false);
        }
    }
}
