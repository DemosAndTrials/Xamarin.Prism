using Prism.Mvvm;

namespace Xamarin.Prism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _title = "Mainpage wellcome";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainViewModel()
        {

        }
    }
}
