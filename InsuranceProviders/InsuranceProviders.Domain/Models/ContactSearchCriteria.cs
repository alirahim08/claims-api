using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceProviders.Domain.Models
{
    public class ContactSearchCriteria
    {
        public int ContactId { get; set; }
        public string insuranceProviderCode { get; set; }
    }
}
