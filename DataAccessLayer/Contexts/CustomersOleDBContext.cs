using DataAccessLayer.Repositories;
using System.Data.SqlClient;

namespace DataAccessLayer.Contexts
{
    internal class CustomersOleDBContext : IOleDBContext, IDisposable
    {
        public CustomersOleDBContext()
        {
            Connection = new SqlConnection();
        }

        public SqlConnection Connection { get; }

        public string DatabaseName => Connection.Database;

        public bool IsEnabled => Connection.State > 0;

        public void Connect(string initalCatalog, string login, string password) 
        {
            SqlConnectionStringBuilder connectionString = new()
            {
                DataSource = @"(localDB)\MSSQLLocalDB",
                InitialCatalog = initalCatalog,
                UserID = login,
                Password = password,
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
