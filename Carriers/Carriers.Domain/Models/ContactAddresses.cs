using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Domain.Models
{
    public class ContactAddresses
    {
        public int AddressId { get; set; }

        public int ContactId { get; set; }

        public int CarrierId { get; set; }

        public string Address { get; set; }

        public string AddressType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }


    }
}
