using Prism.Navigation;
using Xamarin.Prism.ViewModels.Abstract;

namespace Xamarin.Prism.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Wellcome to the main page";
        }
    }
}
