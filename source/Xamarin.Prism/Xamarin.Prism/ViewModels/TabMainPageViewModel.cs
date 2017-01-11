using Prism.Mvvm;

namespace Xamarin.Prism.ViewModels
{
    public class TabMainPageViewModel : BindableBase
    {
        private IApplicationCommands _applicationCommand;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommand; }
            set { SetProperty(ref _applicationCommand, value); }
        }

        public TabMainPageViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
    }
}
