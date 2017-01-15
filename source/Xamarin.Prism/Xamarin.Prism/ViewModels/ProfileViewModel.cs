using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Prism.Services;
using Xamarin.Prism.ViewModels.Abstract;

namespace Xamarin.Prism.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        readonly IAuthenticationService _authentication;
        readonly IPageDialogService _pageDialogService;
        public DelegateCommand LogoutCommand { get; private set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value); }
        }

        private string _instanceUrl;
        public string InstanceUrl
        {
            get { return _instanceUrl; }
            set { SetProperty(ref _instanceUrl, value); }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        private string _photoUrl;
        public string PhotoUrl
        {
            get { return _photoUrl; }
            set { SetProperty(ref _photoUrl, value); }
        }

        public ProfileViewModel(INavigationService navigationService, IAuthenticationService authentication, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _authentication = authentication;
            _pageDialogService = pageDialogService;
            LogoutCommand = new DelegateCommand(Logout);
        }

        private async void Logout()
        {
            if (await _pageDialogService.DisplayAlertAsync
                ("Logout", "Are you sure you wish to logout?", "Accept", "Cancel"))
            {
                await _authentication.LogoutAsync();
                await _navigationService.NavigateAsync("LoginView", useModalNavigation: true);
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            
            if (_authentication.UserAccount != null)
            {
                DisplayName = _authentication.UserAccount.Properties["display_name"];
                Username = _authentication.UserAccount.Username;
                EmailAddress = _authentication.UserAccount.Properties["email"];
                InstanceUrl = _authentication.UserAccount.Properties["instance_url"];
                var img = _authentication.UserAccount.Properties["photo_picture"];
                PhotoUrl = img + "?oauth_token=" + Uri.EscapeUriString(_authentication.UserAccount.Properties["access_token"]);
                
            }
        }
    }
}
