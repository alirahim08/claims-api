namespace Carriers.Domain.Models
{
    public class Carrier
    {
        public int CarrierId { get; set; }
        public string CarrierCode{ get; set; }
        public string CarrierName { get; set; }
        public string Location{ get; set; }
        public string AddressLine1{ get; set; }
        public string AddressLine2{ get; set; }
        public string City{ get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
    }
}
