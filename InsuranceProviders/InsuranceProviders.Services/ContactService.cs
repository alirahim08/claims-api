using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceProviders.Domain;
using InsuranceProviders.Domain.Models;
using InsuranceProviders.Domain.Services;
using InsuranceProviders.Repositories;

namespace InsuranceProviders.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactSearchService _contactSearchService;
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactSearchService contactSearchService, IContactRepository contactRepository)
        {
            this._contactSearchService = contactSearchService;
            this._contactRepository = contactRepository;
        }

        public async Task<ContactCollection> SearchContact(ContactSearchCriteria criteria)
        {
            return await _contactSearchService.SearchContact(criteria);
        }

        public async Task<IEnumerable<Contact>> GetContacts(string insuranceproviderCode)
        {
            return await _contactRepository.GetContacts(insuranceproviderCode);
        }

        public async Task<Contact> GetContact(int contactId)
        {
            return await _contactRepository.GetContact(contactId);
        }

        public async Task<int> DeleteContact(int contactId)
        {
            return await _contactRepository.DeleteContact(contactId);
        }

    

        public async Task<int> UpdateContact(Contact contact)
        {
            return await _contactRepository.UpdateContact(contact);
        }

        public async Task<int> SaveContact(Contact contact)
        {
            return await _contactRepository.SaveContact(contact);
        }

      
    }
}
