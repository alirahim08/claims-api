using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;

namespace InsuranceProviders.Domain.Services
{
    public interface IContactSearchService
    {
        Task<ContactCollection> SearchContact(ContactSearchCriteria criteria);
    }
}
