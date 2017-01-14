using System.Linq;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public const string AppName = "XamarinPrism";

        // new stuff
        public string OrgType { get; set; }
        public Account UserAccount { get; private set; }

        public async Task SetAccount(Account account)
        {
            UserAccount = account;

            //#if  __ANDROID__
            var accountStore = AccountStoreFactory.Create();
            await accountStore.SaveAsync(account, AppName);
            //#endif
        }

        public async Task<bool> IsAuthenticated()
        {
            // Retrieve any stored account information
            var account = await RetrieveAccount();

            // If we already have the account info then we are set
            if (account == null) return false;
            UserAccount = account;
            return true;
        }

        private static async Task<Account> RetrieveAccount()
        {
            var accounts = await AccountStoreFactory.Create().FindAccountsForServiceAsync(AppName);
            var account = accounts.FirstOrDefault();
            return account;
        }
    }
}
