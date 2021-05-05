using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Repositories
{
    public interface ICarrierRepository
    {
        Task<Carrier> GetCarrier(string carrierId);
        Task<Task> SaveCarrier(Carrier carrier);
    }
}