using System;
using System.Threading.Tasks;
using Android.App;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Prism.Droid.CustomViews;
using Xamarin.Prism.Services;
using Xamarin.Prism.ViewModels;
using Xamarin.Prism.Views;

[assembly: ExportRenderer(typeof(LoginPopupView), typeof(LoginPopupRenderer))]
namespace Xamarin.Prism.Droid.CustomViews
{
    class LoginPopupRenderer : PageRenderer
    {

        public LoginPopupRenderer(IUnityContainer container)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            };

            var org = ((e.NewElement as LoginPopupView)?.BindingContext as LoginPopupViewModel)?.NavigationParameter as string;
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
                //IoC.Get<IAuthenticationService>().SetAccount(e.Account);
                //IoC.Get<INavigationService>().To<RootViewModel>();
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
                account.Username = (string)user[Constants.UsernameAccountProperty];
                account.Properties[Constants.EmailAccountProperty] = (string)user[Constants.EmailAccountProperty];
                account.Properties[Constants.PhotoAccountProperty] = (string)user[Constants.PhotoAccountProperty]["picture"];
            }
        }
    }
}