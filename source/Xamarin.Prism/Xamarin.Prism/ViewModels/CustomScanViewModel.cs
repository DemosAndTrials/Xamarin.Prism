using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using Xamarin.Prism.ViewModels.Abstract;
using ZXing;

namespace Xamarin.Prism.ViewModels
{
    public class CustomScanViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        readonly IPageDialogService _pageDialogService;
        public DelegateCommand<Result> ScanResultCommand { get; private set; }
        public DelegateCommand FlashCommand { get; private set; }

        private View _contentView;
        public View ContentView
        {
            get { return _contentView; }
            set { SetProperty(ref _contentView, value); }
        }

        private bool _isScanning;
        public bool IsScanning
        {
            get { return _isScanning; }
            set { SetProperty(ref _isScanning, value); }
        }

        private bool _isTorchOn;
        public bool IsTorchOn
        {
            get { return _isTorchOn; }
            set { SetProperty(ref _isTorchOn, value); }
        }

        public CustomScanViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            ScanResultCommand = new DelegateCommand<Result>(OnScanResult);
            FlashCommand = new DelegateCommand(OnFlashClicked);
            IsScanning = true;
        }

        private void OnFlashClicked()
        {
            IsTorchOn = !IsTorchOn;
        }

        private void OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // Stop analysis until we navigate away so we don't keep reading barcodes
                //_zxing.IsAnalyzing = false;
                IsScanning = false;

                // Show an alert
                await _pageDialogService.DisplayAlertAsync("Scanned Barcode", result.Text, "OK");

                // Navigate away
                await _navigationService.GoBackAsync();
            });
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            IsScanning = true;
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            IsScanning = false;
        }

    }
}
