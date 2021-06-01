using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Carriers.Domain;
using Carriers.Domain.Models;
using Carriers.Domain.Services;
using Carriers.Repositories;

namespace Carriers.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactSearchService contactSearchService, IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        public async Task<ContactCollection> SearchContact(ContactSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetContacts(string carrierCode)
        {
            return await _contactRepository.GetContacts(carrierCode);
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
