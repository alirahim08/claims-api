using System.Threading.Tasks;
using Carriers.Domain;
using Carriers.Domain.Models;
using Carriers.Domain.Services;
using Carriers.Repositories;

namespace Carriers.Services
{
    public class CarrierService: ICarrierService
    {
        private readonly ICarrierSearchService _carrierSearchService;
        private readonly ICarrierRepository _carrierRepository;

        public CarrierService(ICarrierSearchService carrierSearchService, ICarrierRepository carrierRepository )
        {
            this._carrierSearchService = carrierSearchService;
            this._carrierRepository = carrierRepository;
        }

        public async Task<CarrierCollection> SearchCarriers(CarrierSearchCriteria criteria)
        {
            return await _carrierSearchService.SearchCarriers(criteria);
        }

        public async Task<Carrier> GetCarrier(string carrierId)
        {
            return await _carrierRepository.GetCarrier(carrierId);
        }

        public async Task SaveCarrier(Carrier carrier)
        {
            await _carrierRepository.SaveCarrier(carrier);
        }
    }
}