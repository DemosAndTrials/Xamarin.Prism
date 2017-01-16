namespace Xamarin.Prism.Views
{
    public partial class BarcodeScanView
    {
        //ZXingScannerView _zxing;
        //ZXingDefaultOverlay _overlay;

        public BarcodeScanView()
        {
            InitializeComponent();

            //_zxing = new ZXingScannerView
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            //_zxing.OnScanResult += (result) =>
            //    Device.BeginInvokeOnMainThread(async () => {

            //        // Stop analysis until we navigate away so we don't keep reading barcodes
            //        _zxing.IsAnalyzing = false;

            //        // Show an alert
            //        await DisplayAlert("Scanned Barcode", result.Text, "OK");

            //        // Navigate away
            //        await Navigation.PopAsync();
            //    });

            //_overlay = new ZXingDefaultOverlay
            //{
            //    TopText = "Hold your phone up to the barcode",
            //    BottomText = "Scanning will happen automatically",
            //    ShowFlashButton = _zxing.HasTorch,
            //};
            //_overlay.FlashButtonClicked += (sender, e) => {
            //    _zxing.IsTorchOn = !_zxing.IsTorchOn;
            //};
            //var grid = new Grid
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //};
            //grid.Children.Add(_zxing);
            //grid.Children.Add(_overlay);

            //// The root page of your application
            //Content = grid;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    _zxing.IsScanning = true;
        //}

        //protected override void OnDisappearing()
        //{
        //    _zxing.IsScanning = false;

        //    base.OnDisappearing();
        //}
    }
}
