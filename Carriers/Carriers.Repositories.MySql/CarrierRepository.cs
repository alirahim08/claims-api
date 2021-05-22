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

            var query = @"Delete  FROM carriers  WHERE CarrierCode=@carrier_code";

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

        public async Task<IEnumerable<Carrier>> GetCarriers()
        {
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
            ORDER BY CarrierName";
            
            var CarrierList = await _dbRepositiory.GetListAsync<Carrier>(query);
            return CarrierList;
        }

        public async Task<int> SaveCarrier(Carrier carrier)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carrier_code", carrier.CarrierCode);
            parameters.Add("@carrier_name", carrier.CarrierName);
            parameters.Add("@location", carrier.Location);
            parameters.Add("@address_line1", carrier.AddressLine1);
            parameters.Add("@address_line2", carrier.AddressLine2);
            parameters.Add("@city", carrier.City);
            parameters.Add("@state", carrier.State);
            parameters.Add("@zip", carrier.Zip);
            parameters.Add("@country", carrier.Country);
            parameters.Add("@phone", carrier.Phone);
            parameters.Add("@fax", carrier.Fax);
            parameters.Add("@email", carrier.Email);
            parameters.Add("@Website", carrier.Website);
            parameters.Add("@notes", carrier.Notes);

            var query = @"Insert INTO carriers(CarrierCode,CarrierName,Location,AddressLine1,AddressLine2,City,State,Zip,Country,Phone,
                        Fax,Email,Website,Notes) Values (@carrier_code,@carrier_name,@location,@address_line1,@address_line2,@city,@state,
                        @zip,@country,@phone,@fax,@email,@Website,@notes )";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }

        public async Task<int> UpdateCarrier(Carrier carrier)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carrier_code", carrier.CarrierCode);
            parameters.Add("@carrier_name", carrier.CarrierName);
            parameters.Add("@location", carrier.Location);
            parameters.Add("@address_line1", carrier.AddressLine1);
            parameters.Add("@address_line2", carrier.AddressLine2);
            parameters.Add("@city", carrier.City);
            parameters.Add("@state", carrier.State);
            parameters.Add("@zip", carrier.Zip);
            parameters.Add("@country", carrier.Country);
            parameters.Add("@phone", carrier.Phone);
            parameters.Add("@fax", carrier.Fax);
            parameters.Add("@email", carrier.Email);
            parameters.Add("@Website", carrier.Website);
            parameters.Add("@notes", carrier.Notes);

            var query = @"Update carriers
                        set CarrierName = @carrier_name,
                            Location = @location,
                            AddressLine1 = @address_line1,
                            AddressLine2 = @address_line2,
                            City = @city,
                            State = @state,
                            Zip = @zip,
                            Country = @country,
                            Phone = @phone,
                            Fax = @fax,
                            Email = @email,
                            Website = @Website,
                            Notes = @notes 
                        WHERE carriercode = @carrier_code";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }
    }
}