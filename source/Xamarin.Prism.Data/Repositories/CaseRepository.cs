using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Prism.Data.Repositories.Abstract;
using Xamarin.Prism.Model.Contracts.Models;
using Xamarin.Prism.Model.Models;

namespace Xamarin.Prism.Data.Repositories
{
    public class CaseRepository : RepositoryBase
    {
        public Task<IEnumerable<ICase>> GetCasesAsync()
        {
            return Task.Run(() =>
            {
                var list = new List<ICase>();
                // fill fake data
                for (int i = 0; i < 50; i++)
                {
                    list.Add(new Case()
                    {
                        CaseNumber = "000" +i,
                        Description = "some test description 000"+i,
                        Subject = "subject " + i,
                        Reason = "reason " + i
                    });
                }
                IEnumerable<ICase> result = list;
                return result;
            });
        }
    }
}
