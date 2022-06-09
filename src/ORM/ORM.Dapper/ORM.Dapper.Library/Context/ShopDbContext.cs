using System.Data;
using System.Data.SqlClient;

namespace ORM.Dapper.Library.Context
{
    public class ShopDbContext
    {
        private readonly string _connectionString;

        public ShopDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
