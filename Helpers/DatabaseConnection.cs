using Microsoft.Data.SqlClient;

namespace SA_W4.Helpers
{
    public class DatabaseConnection
    {
        private readonly string connectionDocker;

        public DatabaseConnection()
        {
            ConfigurationRoot configuration = (ConfigurationRoot)new ConfigurationBuilder()
             .AddEnvironmentVariables()

            .Build();
            this.connectionDocker = configuration["connectionSqlserver"];
        }

        public SqlConnection Connection(string connectionString)
        {
            connectionString = this.connectionDocker ?? connectionString;

            return new(connectionString);
        }
    }
}
