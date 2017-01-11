using Prism.Mvvm;
using Prism.Navigation;

namespace Xamarin.Prism.ViewModels
{
    public class RootViewViewModel : BindableBase
    {
        readonly INavigationService _navigationService;

        public RootViewViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        
    }
}
