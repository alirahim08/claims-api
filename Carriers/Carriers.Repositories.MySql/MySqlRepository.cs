using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace Carriers.Repositories.MySql
{
    public class MySqlRepository : IDbRepositiory
    {
        private readonly string _connectionString;
        private const int CommandTimeout = 300;
        
        public MySqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // use for buffered queries that return a type
        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                await using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (MySqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }

        // use for buffered queries that do not return a type
        protected async Task WithConnection(Func<IDbConnection, Task> getData)
        {
            try
            {
                await using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (MySqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }

        //use for non-buffered queries that return a type
        protected async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData, Func<TRead, Task<TResult>> process)
        {
            try
            {
                await using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var data = await getData(connection);
                    return await process(data);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (MySqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string query, object parameters=null)
        {
            return await WithConnection(async conn =>
            {
                var response = await conn.QueryAsync<T>(query, parameters, commandTimeout:CommandTimeout);
                return response;
            });
        }
        
        public async Task<T> GetFirstOrDefaultAsync<T>(string query, DynamicParameters parameters=null)
        {
            try
            {
                return await WithConnection(async conn =>
                {
                    var response = await conn.QueryAsync<T>(query, parameters, commandTimeout: CommandTimeout);
                    return response.FirstOrDefault();
                });
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;

                throw;
            }
        }

        public async Task<int> ExecuteAsync<T>(string query, DynamicParameters parameters = null)
        {
            return await WithConnection(async conn =>
            {
                return await conn.ExecuteAsync(query, parameters, commandTimeout:CommandTimeout);
            });
        }
    }
}