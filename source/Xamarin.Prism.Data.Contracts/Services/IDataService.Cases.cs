using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Prism.Model.Contracts.Models;

namespace Xamarin.Prism.Data.Contracts.Services
{
    public partial interface IDataService
    {
        Task<IEnumerable<ICase>> GetCasesAsync();
    }
}
