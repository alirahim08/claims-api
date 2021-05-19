using System.Collections.Generic;
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

        public async Task<int> DeleteCarrier(string carrierCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carrier_code", carrierCode);

            var query = @"Delete  FROM carriers
           WHERE CarrierCode=@carrier_code";

           return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
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
        public async Task<List<Carrier>> GetCarriers(string carrierCode)
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
            WHERE CarrierCode=ifnull(@carrier_code,CarrierCode)";
            var CarrierList = new List<Carrier>();
            CarrierList = (List<Carrier>)await _dbRepositiory.GetListAsync<Carrier>(query, parameters);
            return CarrierList;
        }
        public async Task<Task> SaveCarrier(Carrier carrier)
        {
            throw new System.NotImplementedException();
        }
    }
}