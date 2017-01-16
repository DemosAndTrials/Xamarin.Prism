using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Prism.Services;
using Xamarin.Prism.ViewModels.Abstract;

namespace Xamarin.Prism.ViewModels
{
    public class ShellViewModel : ViewModelBase, IMasterDetailPageOptions
    {
        private readonly INavigationService _navigationService;
        readonly IAuthenticationService _authentication;
        public DelegateCommand<string> NavigateCommand { get; set; }

        private string _userDisplayName;
        public string UserDisplayName
        {
            get { return _userDisplayName; }
            set { SetProperty(ref _userDisplayName, value); }
        }

        private string _instanceUrl;
        public string InstanceUrl
        {
            get { return _instanceUrl; }
            set { SetProperty(ref _instanceUrl, value); }
        }

        private string _photoUrl;
        public string PhotoUrl
        {
            get { return _photoUrl; }
            set { SetProperty(ref _photoUrl, value); }
        }

        public ShellViewModel(INavigationService navigationService, IAuthenticationService authentication)
        {
            _navigationService = navigationService;
            _authentication = authentication;
            NavigateCommand = new DelegateCommand<string>(MenuNavigate);
        }

        private void MenuNavigate(string details)
        {
            _navigationService.NavigateAsync(details);
        }

        private bool _alreadyLoaded;
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (!_alreadyLoaded)
            {
                UserDisplayName = _authentication.UserAccount.Properties["display_name"];
                var img = _authentication.UserAccount.Properties["photo_thumbnail"];
                PhotoUrl = img + "?oauth_token=" + Uri.EscapeUriString(_authentication.UserAccount.Properties["access_token"]);
                InstanceUrl = _authentication.UserAccount.Properties["instance_url"];
                _alreadyLoaded = true;
            }
        }

        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom == TargetIdiom.Desktop; }
        }
    }
}
