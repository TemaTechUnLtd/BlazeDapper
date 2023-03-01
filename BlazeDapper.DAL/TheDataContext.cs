namespace BlazeDapper.DAL
{
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System.Data;

    public class TheDataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public TheDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("TheConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
