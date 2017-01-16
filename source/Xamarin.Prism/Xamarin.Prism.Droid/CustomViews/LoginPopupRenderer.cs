using System;
using System.Threading.Tasks;
using Android.App;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Prism.Data;
using Xamarin.Prism.Droid.CustomViews;
using Xamarin.Prism.ViewModels;
using Xamarin.Prism.Views;

[assembly: ExportRenderer(typeof(LoginPopupView), typeof(LoginPopupRenderer))]
namespace Xamarin.Prism.Droid.CustomViews
{
    class LoginPopupRenderer : PageRenderer
    {
        private LoginPopupViewModel _model;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

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
            var activity = Context as Activity;
            activity?.StartActivity(auth.GetUI(activity));
        }

        private async void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
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