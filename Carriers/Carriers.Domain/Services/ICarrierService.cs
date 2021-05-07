using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Domain.Services
{
    public interface ICarrierService: ICarrierSearchService
    {
        Task<Carrier> GetCarrier(string carrierId);
        Task SaveCarrier(Carrier carrier);
        
    }
}
