using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public interface IAuthenticationService
    {
        Account UserAccount { get; }
        void SetAccount(Account account);
    }
}
