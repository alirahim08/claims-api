using System.Threading.Tasks;
using Carriers.Domain;
using Carriers.Domain.Models;
using Carriers.Domain.Services;

namespace Carriers.Services.Search.Lucene
{
    public class ContactSearchService : IContactSearchService
    {
        public Task<ContactCollection> SearchContact(ContactSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
