using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace TodoListActions.Infrastructure
{
    public class ConnectionFactory
    {
        private static IOptions<DbOptions> _options;

        public ConnectionFactory(IOptions<DbOptions> options)
        {
            _options = options;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_options.Value.ConnectionString);
        }
    }
}
