using System;
using Xamarin.Auth;

namespace Xamarin.Prism.Services
{
    public static class AccountStoreFactory
    {
        public static Func<AccountStore> Create { get; set; } = () => AccountStore.Create();
    }
}
