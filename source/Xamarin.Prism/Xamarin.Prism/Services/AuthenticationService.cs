using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        // new stuff
        public Account UserAccount { get; private set; }

        public void SetAccount(Account account)
        {
            UserAccount = account;
        }
    }
}
