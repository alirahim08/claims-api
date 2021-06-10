using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;

namespace InsuranceProviders.Domain.Services
{
    public interface IInsuranceProviderSearchService
    {
        Task<InsuranceProviderCollection> SearchInsuranceProviders(InsuranceProviderSearchCriteria criteria);
    }
}