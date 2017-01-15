using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Xamarin.Forms;

namespace Xamarin.Prism.ViewModels
{
    public class CameraViewModel : BindableBase
    {
        readonly IPageDialogService _pageDialogService;
        public DelegateCommand TakePhotoCommand { get; private set; }
        public DelegateCommand UploadCommand { get; private set; }

        private ImageSource _photo;
        public ImageSource Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        public CameraViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            TakePhotoCommand = new DelegateCommand(TakePhoto);
            UploadCommand = new DelegateCommand(UploadPicture);
        }

        private async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _pageDialogService.DisplayAlertAsync("No camera", "No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "test.jpg"
            });

            if (file == null)
                return;

            Photo = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void UploadPicture()
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await _pageDialogService.DisplayAlertAsync("No upload", "Picking photo is not supported.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

            Photo = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}
