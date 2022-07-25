using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Threading.Tasks;

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

        public async Task Connect(string initalCatalog, string login, string password) 
        {
            //OleDbConnectionStringBuilder connectionString = new OleDbConnectionStringBuilder()
            //{
            //    Provider = @"Microsoft.ACE.OLEDB.12.0",
            //    DataSource = $"{initalCatalog}",
            //};
            await Task.Delay(5000);

            _connection.ConnectionString = initalCatalog;

            await _connection.OpenAsync();

            OleDbCommand command = new OleDbCommand($"SELECT * FROM Auth WHERE Login='{login}' AND [Password]='{password}'", _connection);
            DbDataReader reader = await command.ExecuteReaderAsync();

            bool isFind= false;

            while (await reader.ReadAsync()) 
            {
                isFind = true;
                break;
            }

            if (!isFind) 
            {
                _connection.Close();
                throw new AccessViolationException("Invalid login or password");
            }   
        }

        public async Task Disconnect() 
        {
            if (_connection.State != 0) 
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetTable()
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM Customers", _connection);
            OleDbDataReader reader = command.ExecuteReader();

            List<Customer> result = new List<Customer>();

            while (await reader.ReadAsync())
            {
                result.Add(new Customer()
                {
                    UID = new Guid(reader.GetString(0)),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Patronymic = reader.GetString(3),
                    Phone = reader.GetString(4),
                    Email = reader.GetString(5),
                });
            }
            return result;
        }

        public async Task RunCommand(string command)
        {
            OleDbCommand cmd = new OleDbCommand(command, _connection);
            await cmd.ExecuteNonQueryAsync();
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
