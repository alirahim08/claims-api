using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Domain.Models
{
    public class ContactPhones
    {
        public int PhoneId { get; set; }

        public int ContactId { get; set; }

        public int CarrierId { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
