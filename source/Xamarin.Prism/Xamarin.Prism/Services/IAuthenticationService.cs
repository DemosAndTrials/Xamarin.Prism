using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public interface IAuthenticationService
    {
        string OrgType { get; set; }
        Account UserAccount { get; }
        void SetAccount(Account account);
    }
}
