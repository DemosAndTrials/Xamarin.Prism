using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public interface IAuthenticationService
    {
        Account UserAccount { get; }
        void SetAccount(Account account);
    }
}
