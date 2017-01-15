using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Prism.iOS.CustomViews;
using Xamarin.Prism.Services;
using Xamarin.Prism.ViewModels;
using Xamarin.Prism.Views;


[assembly: ExportRenderer(typeof(LoginPopupView), typeof(LoginPopupRenderer))]
namespace Xamarin.Prism.iOS.CustomViews
{
    class LoginPopupRenderer : PageRenderer
    {
        private bool _isShown;
        private LoginPopupViewModel _model;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (_isShown) return;
            _isShown = true;

            _model = (Element as LoginPopupView)?.BindingContext as LoginPopupViewModel;
            if (_model == null) return;

            var org = _model.GetOrgType();
            // Initialize the object that communicates with the OAuth service
            var auth = new OAuth2Authenticator(
              Constants.ClientId,
              Constants.Scope,
              new Uri(string.Format(Constants.AuthorizeUrl, org)),
              new Uri(Constants.CallbackUrl));

            // Register an event handler for when the authentication process completes
            auth.Completed += OnAuthenticationCompleted;

            // Display the UI
            PresentViewController(auth.GetUI(), true, null);
        }

        async void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                await FetchUserInfo(e.Account);
                _model.FinishAuthentication(e.Account);
            }
        }

        public async Task FetchUserInfo(Account account)
        {
            var request = new OAuth2Request("GET", new Uri(account.Properties["id"]), null, account);
            var response = await request.GetResponseAsync();
            if (response != null)
            {
                var userJson = response.GetResponseText();
                var user = JObject.Parse(userJson);
                account.Username = (string)user["username"];
                account.Properties["display_name"] = (string)user["display_name"];
                account.Properties["email"] = (string)user["email"];
                account.Properties["photo_picture"] = (string)user["photos"]["picture"];
                account.Properties["photo_thumbnail"] = (string)user["photos"]["thumbnail"];
            }
        }
    }
}