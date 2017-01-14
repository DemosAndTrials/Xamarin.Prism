using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Auth;

namespace Xamarin.Prism.UWP
{
    public class AccountStoreUWP : AccountStore
    {
        public override async Task<List<Account>> FindAccountsForServiceAsync(string serviceId)
        {
            var localFolder = ApplicationData.Current.LocalFolder;

            var files = await localFolder.GetFilesAsync().AsTask().ConfigureAwait(false);

            var accounts = new List<Account>();

            foreach (var file in files.Where(x => x.Name.StartsWith("xamarin.auth.") &&
                                                  x.Name.EndsWith("." + serviceId))
                                      .ToList())
            {
                using (var stream = await file.OpenStreamForReadAsync().ConfigureAwait(false))
                using (var reader = new BinaryReader(stream))
                {
                    var length = reader.ReadInt32();
                    var data = reader.ReadBytes(length);

                    var unprot = (await DataProtectionExtensions.UnprotectAsync(data).ConfigureAwait(false)).ToArray();
                    accounts.Add(Account.Deserialize(Encoding.UTF8.GetString(unprot, 0, unprot.Length)));
                }
            }
            return accounts;
        }

        public override async Task SaveAsync(Account account, string serviceId)
        {
            byte[] data = Encoding.UTF8.GetBytes(account.Serialize());
            byte[] prot = (await DataProtectionExtensions.ProtectAsync(data).ConfigureAwait(false)).ToArray();

            var path = GetAccountPath(account, serviceId);

            var localFolder = ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync(path, CreationCollisionOption.OpenIfExists).AsTask().ConfigureAwait(false);
            using (var stream = await file.OpenStreamForWriteAsync().ConfigureAwait(false))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(prot.Length);
                writer.Write(prot);
            }
        }

        public override async Task DeleteAsync(Account account, string serviceId)
        {
            var path = GetAccountPath(account, serviceId);
            try
            {
                var localFolder = ApplicationData.Current.LocalFolder;
                var file = await localFolder.GetFileAsync(path).AsTask().ConfigureAwait(false);
                await file.DeleteAsync().AsTask().ConfigureAwait(false);
            }
            catch
            {
                // Ignore this error if file doesn't exist
            }
        }

        public override IEnumerable<Account> FindAccountsForService(string serviceId)
        {
            return FindAccountsForServiceAsync(serviceId).Result;
        }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        public override void Save(Account account, string serviceId)
        {
            SaveAsync(account, serviceId);
        }

        public override void Delete(Account account, string serviceId)
        {
            DeleteAsync(account, serviceId);
        }
#pragma warning restore 4014

        private string GetAccountPath(Account account, string serviceId)
        {
            return string.Format("xamarin.auth.{0}.{1}", account.Username, serviceId);
        }
    }
}
