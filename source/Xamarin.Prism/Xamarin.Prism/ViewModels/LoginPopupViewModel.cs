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

        public void FinishAuthentication(Account account)
        {
            // store user account
            _authentication.SetAccount(account);
            // navigate to main page
            _navigationService.NavigateAsync("ShellView/DetailView/MainView", animated: false);
        }
    }
}
