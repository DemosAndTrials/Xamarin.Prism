using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Xamarin.Prism.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(MenuNavigate);
        }

        private void MenuNavigate(string details)
        {
            _navigationService.NavigateAsync(details);
        }
    }
}
