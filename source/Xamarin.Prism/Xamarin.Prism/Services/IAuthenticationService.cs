using System.Threading.Tasks;
using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public interface IAuthenticationService
    {
        string OrgType { get; set; }
        Account UserAccount { get; }
        Task SetAccountAsync(Account account);
        Task<bool> IsAuthenticatedAsync();
        Task LogoutAsync();
    }
}
