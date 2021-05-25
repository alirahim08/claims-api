using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Domain.Services
{
    public interface IContactSearchService
    {
        Task<ContactCollection> SearchContact(ContactSearchCriteria criteria);
    }
}
