using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BlazeDapper.DAL
{
    public class BlazeContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BlazeContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("BlazeConnection");
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
