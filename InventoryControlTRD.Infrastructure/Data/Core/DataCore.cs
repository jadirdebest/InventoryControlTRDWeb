using Dapper;
using InventoryControlTRD.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Core
{
    public class DataCore<T> : IDataCore<T> where T : class
    {
        public async Task ExecuteAsync(string query)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query);
            }
        }

        public async Task ExecuteAsync(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query,obj);
            }
        }

        public Task<IEnumerable<T>> QueryAsync(string query)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return conn.QueryAsync<T>(query);
            }
        }

        public Task<IEnumerable<T>> QueryAsync(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return conn.QueryAsync<T>(query,obj);
            }
        }

        public Task<T> QuerySingleAsync(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefaultAsync<T>(query, obj);
            }
        }
    }
}
