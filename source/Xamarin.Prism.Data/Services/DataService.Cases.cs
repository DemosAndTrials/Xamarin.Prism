using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Prism.Model.Contracts.Models;

namespace Xamarin.Prism.Data.Services
{
    public partial class DataService
    {
        public Task<IEnumerable<ICase>> GetCasesAsync()
        {
            return _caseRepository.GetCasesAsync();
        }
    }
}
