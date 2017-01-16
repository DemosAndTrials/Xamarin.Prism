using System.Linq;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Prism.Data.Contracts.Services;

namespace Xamarin.Prism.Data.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        // new stuff
        public string OrgType { get; set; }
        public Account UserAccount { get; private set; }

        public async Task SetAccountAsync(Account account)
        {
            UserAccount = account;

            //#if  __ANDROID__
            var accountStore = AccountStoreFactory.Create();
            await accountStore.SaveAsync(account, Constants.AppName);
            //#endif
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            // Retrieve any stored account information
            UserAccount = await RetrieveAccount();

            return UserAccount != null;
        }

        private async Task<Account> RetrieveAccount()
        {
            var accounts = await AccountStoreFactory.Create().FindAccountsForServiceAsync(Constants.AppName);
            var account = accounts.FirstOrDefault();
            return account;
        }

        public async Task LogoutAsync()
        {
            await AccountStoreFactory.Create().DeleteAsync(UserAccount, Constants.AppName);
            UserAccount = null;
        }
    }
}
