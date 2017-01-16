using System;
using Xamarin.Auth;

namespace Xamarin.Prism.Data.Services
{
    public static class AccountStoreFactory
    {
        public static Func<AccountStore> Create { get; set; } = () => AccountStore.Create();
    }
}
