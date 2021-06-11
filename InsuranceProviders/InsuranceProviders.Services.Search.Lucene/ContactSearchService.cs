using System.Threading.Tasks;
using InsuranceProviders.Domain;
using InsuranceProviders.Domain.Models;
using InsuranceProviders.Domain.Services;

namespace InsuranceProviders.Services.Search.Lucene
{
    public class ContactSearchService : IContactSearchService
    {
        public Task<ContactCollection> SearchContact(ContactSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
