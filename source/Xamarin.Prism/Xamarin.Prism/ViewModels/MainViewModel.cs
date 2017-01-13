using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Prism.ViewModels.Abstract;

namespace Xamarin.Prism.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _title = "Mainpage wellcome";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
