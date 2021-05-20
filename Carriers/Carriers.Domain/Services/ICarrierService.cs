using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Domain.Services
{
    public interface ICarrierService: ICarrierSearchService
    {
        Task<Carrier> GetCarrier(string carrierCode);
        Task SaveCarrier(Carrier carrier);

        Task<IEnumerable<Carrier>> GetCarriers();
        Task<int> DeleteCarrier(string carrierCode);

    }
}
