using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carriers.Domain.Models;


namespace Carriers.Domain.Services
{
    public interface IContactService : IContactSearchService
    {
        Task<IEnumerable<Contact>> GetContacts(string carrierCode);

        Task<Contact> GetContact(int contactId);

        Task<int> DeleteContact(int contactId);

        Task<int> SaveContact(Contact contact);

        Task<int> UpdateContact(Contact contact);
    }
}
