using System.Threading.Tasks;
using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public interface IAuthenticationService
    {
        string OrgType { get; set; }
        Account UserAccount { get; }
        Task SetAccount(Account account);
        Task<bool> IsAuthenticated();
    }
}
