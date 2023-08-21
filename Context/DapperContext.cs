using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Referralapi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration? _configuration;
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlMapper.Settings.CommandTimeout = 60;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
