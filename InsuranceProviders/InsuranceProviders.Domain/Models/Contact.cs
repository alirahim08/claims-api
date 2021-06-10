using System;
using System.Collections.Generic;

namespace InsuranceProviders.Domain.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public int insuranceProviderId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<ContactPhones> ContactPhonesList { get; set; }

        public IEnumerable<ContactAddresses> ContactAddressesList { get; set; }
    }
}
