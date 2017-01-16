using Xamarin.Prism.Data.Contracts.Services;
using Xamarin.Prism.Data.Repositories;

namespace Xamarin.Prism.Data.Services
{
    /// <summary>
    /// Data Service
    /// - init
    /// </summary>
    public partial class DataService : IDataService
    {
        private CaseRepository _caseRepository;
        public DataService(CaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }
    }
}
