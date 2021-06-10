using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;

namespace InsuranceProviders.Domain.Services
{
    public interface IInsuranceProviderService: IInsuranceProviderSearchService
    {
        Task<InsuranceProvider> GetInsuranceProvider(string insuranceProviderCode);

        Task<int> SaveInsuranceProvider(InsuranceProvider insuranceProvider);

        Task<IEnumerable<InsuranceProvider>> GetInsuranceProviders();

        Task<int> DeleteInsuranceProvider(string insuranceProviderCode);

        Task<int> UpdateInsuranceProvider(InsuranceProvider insuranceProvider);
    }
}
