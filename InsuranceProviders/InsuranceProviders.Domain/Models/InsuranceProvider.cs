namespace InsuranceProviders.Domain.Models
{
    public class InsuranceProvider
    {
        public int InsuranceId { get; set; }
        public string InsuranceCode { get; set; }
        public string InsuranceName { get; set; }
        public string PolicyNumber { get; set; }
        public string Corporate { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

    }
}
