using System.Collections.ObjectModel;
using Prism.Navigation;
using Xamarin.Prism.Data.Contracts.Services;
using Xamarin.Prism.Model.Contracts.Models;
using Xamarin.Prism.ViewModels.Abstract;

namespace Xamarin.Prism.ViewModels
{
    public class CasesViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private ObservableCollection<ICase> _cases;
        public ObservableCollection<ICase> Cases
        {
            get { return _cases; }
            set { SetProperty(ref _cases, value); }
        }

        public CasesViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            var items = await _dataService.GetCasesAsync();
            Cases = new ObservableCollection<ICase>(items);
        }
    }
}
