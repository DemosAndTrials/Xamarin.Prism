﻿using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Prism.Services;

namespace Xamarin.Prism.ViewModels
{
    public class ProfileViewModel : BindableBase, INavigationAware
    {
        private readonly IAuthenticationService _authentication;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        public ProfileViewModel(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (_authentication.UserAccount != null)
            {
                Username = _authentication.UserAccount.Username;
                EmailAddress = _authentication.UserAccount.Properties[Constants.EmailAccountProperty];
            }
        }
    }
}