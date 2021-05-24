using System.Collections.Generic;
using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Repositories
{
    public interface ICarrierRepository
    {
        Task<Carrier> GetCarrier(string carrierId);

        Task<IEnumerable<Carrier>> GetCarriers();

        Task<int> DeleteCarrier(string carrierId); 

        Task<int> SaveCarrier(Carrier carrier);

        Task<int> UpdateCarrier(Carrier carrier);

    }
}