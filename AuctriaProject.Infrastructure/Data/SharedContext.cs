using AuctriaProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace AuctriaProject.Infrastructure.Data
{
    public class SharedContext : DbContext, ISharedContext 
    {
        private readonly IConfiguration _configuration;
        private readonly SemaphoreSlim _executeBatcher = new SemaphoreSlim(4, 12);

        public SharedContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object queryParameters = null)
        {
            try
            {
                await _executeBatcher.WaitAsync();

                var con = _configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection sqlconn = new SqlConnection(con))
                {
                    try
                    {
                        return await sqlconn.QueryAsync<T>(query, queryParameters, null, 60);
                    }
                    finally
                    {
                        sqlconn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _executeBatcher.Release();
            }
        }

        public async Task<int> ExecuteAsync(string query, object queryParameters, int? commandTimeout = null)
        {
            try
            {
                await _executeBatcher.WaitAsync();

                int result = 0;
                var con = _configuration["ConnectionStrings:DefaultConnection"];

                using (SqlConnection sqlconn = new SqlConnection(con))
                {
                    try
                    {
                        if (sqlconn.State == ConnectionState.Closed)
                        {
                            sqlconn.Open();
                        }
                        result = await sqlconn.ExecuteAsync(query, queryParameters, null, commandTimeout.GetValueOrDefault(60));
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    finally
                    {
                        if (sqlconn.State == ConnectionState.Open)
                        {
                            sqlconn.Close();
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _executeBatcher.Release();
            }
        }
    }
}