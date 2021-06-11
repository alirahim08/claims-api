using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;

namespace InsuranceProviders.Repositories
{
    public interface IInsuranceProviderRepository
    {
        Task<InsuranceProvider> GetInsuranceProvider(string insuranceProviderId);

        Task<IEnumerable<InsuranceProvider>> GetInsuranceProviders();

        Task<int> DeleteInsuranceProvider(string insuranceProviderId); 

        Task<int> SaveInsuranceProvider(InsuranceProvider insuranceProvider);

        Task<int> UpdateInsuranceProvider(InsuranceProvider insuranceProvider);

    }
}