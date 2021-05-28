using System.Collections.Generic;
using System.Threading.Tasks;
using Carriers.Domain.Models;
using Dapper;

namespace Carriers.Repositories.MySql
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbRepositiory _dbRepositiory;

        public ContactRepository(IDbRepositiory dbRepositiory)
        {
            _dbRepositiory = dbRepositiory;
        }

        public async Task<IEnumerable<Contact>> GetContacts(string carrierCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carrier_code", carrierCode);

            var query = @"SELECT 
                            ct.ContactId,
                            ct.CarrierId,
                            ct.Name,
                            ct.Title,
                            ct.Location,
                            ct.CreatedDate,
                            ct.CreatedBy,
                            ct.ModifiedDate,
                            ct.ModifiedBy
                        FROM carriers c
            inner join Contact ct on c.carrierid = ct.carrierid
            WHERE c.CarrierCode= @carrier_code";

            var ContactList = await _dbRepositiory.GetListAsync<Contact>(query, parameters);


            
            foreach (Contact objContact in ContactList)
            {

               
                var ContactPhoneList = await GetContactPhones(objContact.ContactId);
                objContact.ContactPhonesList = ContactPhoneList;


                var ContactAddressesList = await GetContactAddresses(objContact.ContactId);
                objContact.ContactAddressesList = ContactAddressesList;
                
            }
            return ContactList;
        }

        public async Task<Contact> GetContact(int contactId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", contactId);

            var query = @"SELECT 
                            ct.ContactId,
                            ct.CarrierId,
                            ct.Name,
                            ct.Title,
                            ct.Location,
                            ct.CreatedDate,
                            ct.CreatedBy,
                            ct.ModifiedDate,
                            ct.ModifiedBy
                        FROM carriers c
            inner join Contact ct on c.carrierid = ct.carrierid
            WHERE ct.ContactId = @contact_id";

            var Contact = await _dbRepositiory.GetFirstOrDefaultAsync<Contact>(query, parameters);

            var ContactPhoneList = await GetContactPhones(Contact.ContactId);
            Contact.ContactPhonesList = ContactPhoneList;


            var ContactAddressesList = await GetContactAddresses(Contact.ContactId);
            Contact.ContactAddressesList = ContactAddressesList;

            return Contact;

        }


        public async Task<IEnumerable<ContactPhones>> GetContactPhones(int contactId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", contactId);

            var query = @"SELECT 
                            PhoneId,
                            ContactId,
                            CarrierId,
                            PhoneNumber,
                            PhoneType,
                            CreatedDate,
                            CreatedBy,
                            ModifiedDate,
                            ModifiedBy
                        FROM ContactPhones
            WHERE ContactId = @contact_id";
            var ContactPhonesList = await _dbRepositiory.GetListAsync<ContactPhones>(query, parameters);
            return ContactPhonesList;
        }

        public async Task<IEnumerable<ContactAddresses>> GetContactAddresses(int contactId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", contactId);

            var query = @"SELECT 
                            AddressId,
                            ContactId,
                            CarrierId,
                            Address,
                            AddressType,
                            CreatedDate,
                            CreatedBy,
                            ModifiedDate,
                            ModifiedBy
                        FROM ContactAddresses
            WHERE ContactId = @contact_id";
            var ContactAddressesList = await _dbRepositiory.GetListAsync<ContactAddresses>(query, parameters);
            return ContactAddressesList;
        }

    }
}
