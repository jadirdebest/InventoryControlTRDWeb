using System.Data;
using System.Data.SqlClient;

namespace InventoryControlTRD.Infrastructure.Configurations
{
    public class ConnectionProvider
    {
        private readonly string _connectionString;

        public ConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
