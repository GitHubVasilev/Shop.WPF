using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    internal class OrderMSSQLContext : IMSSQLContext<Order>, IDisposable
    {
        private readonly SqlConnection _connection;

        public OrderMSSQLContext()
        {
            _connection = new();
        }

        public bool IsEnabled => _connection.State > 0;

        public string DatabaseName => _connection.Database;

        public async Task Connect(string initialCatalog)
        {
            //SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
            //{
            //    DataSource = @"(localDB)\MSSQLLocalDB",
            //    InitialCatalog = initialCatalog,
            //    IntegratedSecurity = false,
            //    Pooling = true
            //};
            if (!initialCatalog.Contains("MultipleActiveResultSets=True")) 
            {
                initialCatalog += ";MultipleActiveResultSets=True";
            }
            _connection.ConnectionString = initialCatalog;
            await _connection.OpenAsync();
        }

        public async Task Disconnect()
        {
            await _connection.CloseAsync();
        } 

        public async Task<IEnumerable<Order>> GetTable()
        {
            SqlCommand command = new("SELECT * FROM Orders", _connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Order> result = new();

            while (await reader.ReadAsync()) 
            {
                result.Add(new Order() 
                {
                    UID = new Guid(reader.GetString(0)),
                    EmailCustomer = reader.GetString(1),
                    Atricle = reader.GetInt32(2),
                    NameProduct = reader.GetString(3),
                });
            }

            return result;

        }

        public async Task RunCommand(string command)
        {
            SqlCommand cmd = new(command, _connection);

            await cmd.ExecuteNonQueryAsync();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
