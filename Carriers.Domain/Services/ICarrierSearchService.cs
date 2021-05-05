using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Domain.Services
{
    public interface ICarrierSearchService
    {
        Task<CarrierCollection> SearchCarriers(CarrierSearchCriteria criteria);
    }
}