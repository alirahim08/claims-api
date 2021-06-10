using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;
using Dapper;

namespace InsuranceProviders.Repositories.MySql
{
    public class InsuranceProviderRepository : IInsuranceProviderRepository
    {
        private readonly IDbRepositiory _dbRepositiory;
        public InsuranceProviderRepository(IDbRepositiory dbRepositiory)
        {
            _dbRepositiory = dbRepositiory;
        }

        public async Task<int> DeleteInsuranceProvider(string insuranceproviderCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@insuranceprovider_code", insuranceproviderCode);

            var query = @"Delete  FROM insurance  WHERE insuranceCode=@insuranceprovider_code";

           return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }

        public async Task<InsuranceProvider> GetInsuranceProvider(string insuranceproviderCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@insuranceprovider_code", insuranceproviderCode);

            var query = @"SELECT 
                           insuranceId,
                            insuranceCode,
                            insuranceName,
                            PolicyNumber,
                            Corporate,
                            Address,
                            Location,
                            Phone,
                            Fax,
                            Email,
                            Website
                        FROM insurance
           WHERE insuranceCode=@insuranceprovider_code";

            var insuranceprovider = await _dbRepositiory.GetFirstOrDefaultAsync<InsuranceProvider>(query, parameters);
            return insuranceprovider;
        }

        public async Task<IEnumerable<InsuranceProvider>> GetInsuranceProviders()
        {
            var query = @"SELECT 
                            insuranceId,
                            insuranceCode,
                            insuranceName,
                            PolicyNumber,
                            Corporate,
                            Address,
                            Location,
                            Phone,
                            Fax,
                            Email,
                            Website
                        FROM insurance
            ORDER BY insuranceName";
            
            var insuranceproviderList = await _dbRepositiory.GetListAsync<InsuranceProvider>(query);
            return insuranceproviderList;
        }

        public async Task<int> SaveInsuranceProvider(InsuranceProvider insurance)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@insurance_code", insurance.InsuranceCode);
            parameters.Add("@insurance_name", insurance.InsuranceName);
            parameters.Add("@policy_number", insurance.PolicyNumber);
            parameters.Add("@corporate", insurance.Corporate);
            parameters.Add("@address", insurance.Address);
            parameters.Add("@location", insurance.Location);
            parameters.Add("@phone", insurance.Phone);
            parameters.Add("@fax", insurance.Fax);
            parameters.Add("@email", insurance.Email);
            parameters.Add("@Website", insurance.Website);

            var query = @"Insert INTO Insurance(InsuranceCode,InsuranceName,PolicyNumber,Corporate,Address,Location,Phone,Fax,Email,Website) 
                        Values (@insurance_code,@insurance_name,@policy_number,@corporate,@address,@location,@phone,@fax,@email,@Website)";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }

        public async Task<int> UpdateInsuranceProvider(InsuranceProvider insurance)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@insurance_code", insurance.InsuranceCode);
            parameters.Add("@insurance_name", insurance.InsuranceName);
            parameters.Add("@policy_number", insurance.PolicyNumber);
            parameters.Add("@corporate", insurance.Corporate);
            parameters.Add("@address", insurance.Address);
            parameters.Add("@location", insurance.Location);
            parameters.Add("@phone", insurance.Phone);
            parameters.Add("@fax", insurance.Fax);
            parameters.Add("@email", insurance.Email);
            parameters.Add("@Website", insurance.Website);

            var query = @"Update insurance
                        set InsuranceCode = @insurance_code,
                            InsuranceName = @insurance_name,
                            PolicyNumber = @policy_number,
                            Corporate = @corporate,
                            Address = @address,
                            Location = @location,
                            Phone = @phone,
                            Fax = @fax,
                            Email = @email,
                            Website =@Website
                        WHERE insurancecode = @insurance_code";


            return await _dbRepositiory.ExecuteAsync<int>(query, parameters);
        }
    }
}