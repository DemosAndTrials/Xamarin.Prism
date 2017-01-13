using Prism.Mvvm;
using Prism.Navigation;

namespace Xamarin.Prism.ViewModels.Abstract
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
