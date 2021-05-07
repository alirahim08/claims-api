using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Repositories.MySql
{
    public class CarrierRepository : ICarrierRepository
    {
        public Task<Carrier> GetCarrier(string carrierId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Task> SaveCarrier(Carrier carrier)
        {
            throw new System.NotImplementedException();
        }
    }
}