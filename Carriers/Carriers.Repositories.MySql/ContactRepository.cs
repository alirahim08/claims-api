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

        public async Task<int> DeleteContact(int ContactId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Contact_Id", ContactId);

            var query = @"Delete  From Contact  WHERE ContactId = @Contact_Id";

            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }
        public async Task<int> SaveContact(Contact contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carrier_id", contact.CarrierId);
            parameters.Add("@contact_name", contact.Name);
            parameters.Add("@contact_title", contact.Title);
            parameters.Add("@contact_location", contact.Location);
            parameters.Add("@created_by", contact.CreatedBy);
            parameters.Add("@created_date", contact.CreatedDate);




            var query = @"INSERT INTO carriers_db.Contact(CarrierId,Name,Title,Location,CreatedDate,CreatedBy)
                        VALUES
                        (@carrier_id,@contact_name,@contact_title,@contact_location,@created_date,@created_by);
                        SELECT LAST_INSERT_ID();";


            //return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
            var result = await _dbRepositiory.GetFirstOrDefaultAsync<int>(query, parameters);

            contact.ContactId =  (int)result;

            foreach (ContactPhones contactPhone in contact.ContactPhonesList)
            {
                contactPhone.ContactId = (int)result;
                await SaveContactPhones(contactPhone);
            }

            foreach (ContactAddresses contactAddress in contact.ContactAddressesList)
            {
                contactAddress.ContactId = (int)result;
                await SaveContactAddresses(contactAddress);
            }

            return result;
        }

        public async Task<int> SaveContactPhones(ContactPhones contactPhone)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", contactPhone.ContactId);
            parameters.Add("@carrier_id", contactPhone.CarrierId);
            parameters.Add("@phone_number", contactPhone.PhoneNumber);
            parameters.Add("@phone_type", contactPhone.PhoneType);
            parameters.Add("@created_by", contactPhone.CreatedBy);
            parameters.Add("@created_date", contactPhone.CreatedDate);


            var query = @"INSERT INTO carriers_db.ContactPhones(ContactId,CarrierId,PhoneNumber,PhoneType,CreatedDate,CreatedBy)
                        VALUES
                        (@contact_id,@carrier_id,@phone_number,@phone_type,@created_date,@created_by);";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }

        public async Task<int> SaveContactAddresses(ContactAddresses contactAddress)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", contactAddress.ContactId);
            parameters.Add("@carrier_id", contactAddress.CarrierId);
            parameters.Add("@address", contactAddress.Address);
            parameters.Add("@address_type", contactAddress.AddressType);
            parameters.Add("@created_by", contactAddress.CreatedBy);
            parameters.Add("@created_date", contactAddress.CreatedDate);


            var query = @"INSERT INTO carriers_db.ContactAddresses(ContactId,CarrierId,Address,AddressType,CreatedDate,CreatedBy)
                        VALUES
                        (@contact_id,@carrier_id,@address,@address_type,@created_date,@created_by);";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }

        public async Task<int> UpdateContact(Contact contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", contact.ContactId);
            parameters.Add("@carrier_id", contact.CarrierId);
            parameters.Add("@contact_name", contact.Name);
            parameters.Add("@conact_title", contact.Title);
            parameters.Add("@contact_location", contact.Location);
            parameters.Add("@modified_by", contact.ModifiedBy);
            parameters.Add("@modified_date", contact.ModifiedDate);

            var query = @"UPDATE carriers_db.Contact
                        SET
                        CarrierId = @carrier_id,
                        Name = @contact_name,
                        Title = @conact_title,
                        Location = @contact_location,
                        ModifiedDate = @modified_by,
                        ModifiedBy = @modified_date
                        WHERE ContactId = @contact_id
                        ";


            var result = await _dbRepositiory.ExecuteAsync<int>(query, parameters);

            foreach (ContactPhones contactPhone in contact.ContactPhonesList)
            {
                if (contactPhone.PhoneId > 0)
                {
                    await UpdateContactPhones(contactPhone);
                }
                else
                {
                    await SaveContactPhones(contactPhone);
                }
            }

            foreach (ContactAddresses contactAddress in contact.ContactAddressesList)
            {
                if (contactAddress.AddressId > 0)
                {
                    await UpdateContactAddresses(contactAddress);
                }
                else
                {
                    await SaveContactAddresses(contactAddress);
                }
            }

            return result;
        }

        public async Task<int> UpdateContactPhones(ContactPhones contactPhone)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@phone_id", contactPhone.PhoneId);
            parameters.Add("@carrier_id", contactPhone.CarrierId);
            parameters.Add("@phone_number", contactPhone.PhoneNumber);
            parameters.Add("@phone_type", contactPhone.PhoneType);
            parameters.Add("@modified_by", contactPhone.ModifiedBy);
            parameters.Add("@modified_date", contactPhone.ModifiedDate);

            var query = @"UPDATE carriers_db.ContactPhones
                        SET
                        CarrierId = @carrier_id,
                        PhoneNumber = @phone_number,
                        PhoneType = @phone_type,
                        ModifiedDate = @modified_by,
                        ModifiedBy = @modified_date
                        WHERE PhoneId = @phone_id";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }

        public async Task<int> UpdateContactAddresses(ContactAddresses contactAddress)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@address_id", contactAddress.AddressId);
            parameters.Add("@carrier_id", contactAddress.CarrierId);
            parameters.Add("@address", contactAddress.Address);
            parameters.Add("@address_type", contactAddress.AddressType);
            parameters.Add("@modified_by", contactAddress.ModifiedBy);
            parameters.Add("@modified_date", contactAddress.ModifiedDate);

            var query = @"UPDATE carriers_db.ContactAddresses
                        SET
                        CarrierId = @carrier_id,
                        Address = @address,
                        AddressType = @address_type,
                        ModifiedDate = @modified_by,
                        ModifiedBy = @modified_date
                        WHERE AddressId = @address_id";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }
    }
}
