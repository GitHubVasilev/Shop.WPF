using DataAccessLayer.Repositories;
using System.Data.SqlClient;

namespace DataAccessLayer.Contexts
{
    internal class OrderMSSQLContext : IMSSQLContext, IDisposable
    {
        public OrderMSSQLContext()
        {
            Connection = new();
        }

        public SqlConnection Connection { get; }

        public bool IsEnabled => Connection.State > 0;

        public string DatabaseName => Connection.Database;

        public void Connect(string initialCatalog)
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localDB)\MSSQLLocalDB",
                InitialCatalog = initialCatalog,
                IntegratedSecurity = false,
                Pooling = true
            };

            Connection.ConnectionString = connectionString.ConnectionString;
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
