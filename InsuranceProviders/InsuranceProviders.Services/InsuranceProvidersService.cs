using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceProviders.Domain;
using InsuranceProviders.Domain.Models;
using InsuranceProviders.Domain.Services;
using InsuranceProviders.Repositories;

namespace InsuranceProviders.Services
{
    public class InsuranceProviderService : IInsuranceProviderService
    {
        private readonly IInsuranceProviderSearchService _insuranceproviderSearchService;
        private readonly IInsuranceProviderRepository _insuranceproviderRepository;

        public InsuranceProviderService(IInsuranceProviderSearchService insuranceproviderSearchService, IInsuranceProviderRepository insuranceproviderRepository )
        {
            this._insuranceproviderSearchService = insuranceproviderSearchService;
            this._insuranceproviderRepository = insuranceproviderRepository;
        }

        public async Task<InsuranceProviderCollection> SearchInsuranceProviders(InsuranceProviderSearchCriteria criteria)
        {
            return await _insuranceproviderSearchService.SearchInsuranceProviders(criteria);
        }

        public async Task<InsuranceProvider> GetInsuranceProvider(string insuranceProviderCode)
        {
            return await _insuranceproviderRepository.GetInsuranceProvider(insuranceProviderCode);
        }

        public async Task<int> SaveInsuranceProvider(InsuranceProvider insuranceprovider)
        {
            return await _insuranceproviderRepository.SaveInsuranceProvider(insuranceprovider);
        }


        public async Task<int> UpdateInsuranceProvider(InsuranceProvider insuranceprovider)
        {
            return await _insuranceproviderRepository.UpdateInsuranceProvider(insuranceprovider);
        }

        public async Task<IEnumerable<InsuranceProvider>> GetInsuranceProviders()
        {
            return await _insuranceproviderRepository.GetInsuranceProviders();
        }

        public async Task<int> DeleteInsuranceProvider(string insuranceProviderCode)
        {
           return await _insuranceproviderRepository.DeleteInsuranceProvider(insuranceProviderCode);
        }
    }
}