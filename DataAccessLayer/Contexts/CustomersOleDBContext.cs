using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace DataAccessLayer.Contexts
{
    internal class CustomersOleDBContext : IOleDBContext<Customer>, IDisposable
    {
        private readonly OleDbConnection _connection;

        public CustomersOleDBContext()
        {
            _connection = new OleDbConnection();
        }

        public string DatabaseName => _connection.Database;

        public bool IsEnabled => _connection.State > 0;

        public void Connect(string initalCatalog, string login, string password) 
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={initalCatalog};Persist Security Info=True";

            _connection.ConnectionString = connectionString;

            _connection.Open();
        }

        public void Disconnect() 
        {
            _connection.Close();
        }

        public IEnumerable<Customer> GetTable()
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM Customers", _connection);
            OleDbDataReader reader = command.ExecuteReader();

            List<Customer> result = new List<Customer>();

            while (reader.Read())
            {
                result.Add(new Customer()
                {
                    UID = reader.GetGuid(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Patronymic = reader.GetString(3),
                    Phone = reader.GetInt32(4),
                    Email = reader.GetString(5),
                });
            }
            return result;
        }

        public void RunCommand(string command)
        {
            OleDbCommand cmd = new OleDbCommand(command, _connection);
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
