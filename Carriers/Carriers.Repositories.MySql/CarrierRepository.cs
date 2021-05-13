using System.Threading.Tasks;
using Carriers.Domain.Models;
using Dapper;

namespace Carriers.Repositories.MySql
{
    public class CarrierRepository : ICarrierRepository
    {
        private readonly IDbRepositiory _dbRepositiory;
        public CarrierRepository(IDbRepositiory dbRepositiory)
        {
            _dbRepositiory = dbRepositiory;
        }

        public async Task<Carrier> GetCarrier(string carrierCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carrier_code", carrierCode);

            var query = @"SELECT 
                            CarrierId,
                            CarrierCode,
                            CarrierName,
                            Location,
                            AddressLine1,
                            AddressLine2,
                            City,
                            State,
                            Zip,
                            Country,
                            Phone,
                            Fax,
                            Email,
                            Website,
                            Notes
                        FROM carriers
                        WHERE CarrierCode=@carrier_code";

            var carrier = await _dbRepositiory.GetFirstOrDefaultAsync<Carrier>(query, parameters);

            return carrier;
        }

        public async Task<Task> SaveCarrier(Carrier carrier)
        {
            throw new System.NotImplementedException();
        }
    }
}