using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceProviders.Domain.Models
{
    public class ContactAddresses
    {
        public int AddressId { get; set; }

        public int ContactId { get; set; }

        public int insuranceProviderId { get; set; }

        public string Address { get; set; }

        public string AddressType { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }


    }
}
