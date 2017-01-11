using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var p = new NavigationParameters { { "orgType", org } };
            _navigationService.NavigateAsync("LoginPopupView", p);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (NeedsLogin())
            {
                // start login process
            }
            else
            {
                _navigationService.NavigateAsync("ShellView");
            }
        }

        private bool NeedsLogin()
        {
            try
            {
                // check if user authenticated here
                return _authentication.UserAccount == null;
            }
            catch (Exception e)
            {
                // needs logger
                Debug.WriteLine(e);
            }
            return true;
        }
    }
}
