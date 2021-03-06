using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Carriers.Domain;
using Carriers.Domain.Models;
using Carriers.Domain.Services;
using Carriers.Repositories;

namespace Carriers.Services
{
    public class CarrierService: ICarrierService
    {
        private readonly ICarrierRepository _carrierRepository;

        public CarrierService(ICarrierSearchService carrierSearchService, ICarrierRepository carrierRepository )
        {
            this._carrierRepository = carrierRepository;
        }

        public async Task<CarrierCollection> SearchCarriers(CarrierSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<Carrier> GetCarrier(string carrierCode)
        {
            return await _carrierRepository.GetCarrier(carrierCode);
        }

        public async Task<int> SaveCarrier(Carrier carrier)
        {
            return await _carrierRepository.SaveCarrier(carrier);
        }


        public async Task<int> UpdateCarrier(Carrier carrier)
        {
            return await _carrierRepository.UpdateCarrier(carrier);
        }

        public async Task<IEnumerable<Carrier>> GetCarriers()
        {
            return await _carrierRepository.GetCarriers();
        }

        public async Task<int> DeleteCarrier(string carrierCode)
        {
           return await _carrierRepository.DeleteCarrier(carrierCode);
        }
    }
}