using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;

namespace InsuranceProviders.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts(string insuranceProviderCode);

        Task<Contact> GetContact(int contactId);

        Task<int> DeleteContact(int contactId);

        Task<int> SaveContact(Contact contact);

        Task<int> UpdateContact(Contact contact);
    }
}
