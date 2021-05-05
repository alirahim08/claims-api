using System.Threading.Tasks;
using Carriers.Domain;
using Carriers.Domain.Models;
using Carriers.Domain.Services;

namespace Carriers.Services.Search.Lucene
{
    public class CarrierSearchService : ICarrierSearchService
    {
        public Task<CarrierCollection> SearchCarriers(CarrierSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}