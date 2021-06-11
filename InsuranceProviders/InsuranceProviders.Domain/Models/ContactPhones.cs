using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceProviders.Domain.Models
{
    public class ContactPhones
    {
        public int PhoneId { get; set; }

        public int ContactId { get; set; }

        public int insuranceProviderId { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneType { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
