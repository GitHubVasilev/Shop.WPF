using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public void Connect(string initialCatalog)
        {
            //SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
            //{
            //    DataSource = @"(localDB)\MSSQLLocalDB",
            //    InitialCatalog = initialCatalog,
            //    IntegratedSecurity = false,
            //    Pooling = true
            //};

            _connection.ConnectionString = initialCatalog;
            _connection.Open();
        }

        public void Disconnect()
        {
            _connection.Close();
        } 

        public IEnumerable<Order> GetTable()
        {
            SqlCommand command = new("SELECT * FROM Orders", _connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Order> result = new();

            while (reader.Read()) 
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

        public void RunCommand(string command)
        {
            SqlCommand cmd = new(command, _connection);

            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
