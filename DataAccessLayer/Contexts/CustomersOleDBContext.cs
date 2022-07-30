using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    /// <summary>
    /// Класс для упралвения источником данных о Покупателях
    /// </summary>
    internal class CustomersOleDBContext : IOleDBContext<Customer>, IDisposable
    {
        private readonly OleDbConnection _connection;

        public CustomersOleDBContext()
        {
            _connection = new OleDbConnection();
        }

        /// <summary>
        /// Строка подключения
        /// </summary>
        public string DatabaseName => _connection.Database;

        /// <summary>
        /// Статус подключения. True - подключено, False - отключено
        /// </summary>
        public bool IsEnabled => _connection.State > 0;

        /// <summary>
        /// Создает запрос на подключения к источнику данных
        /// </summary>
        /// <param name="initalCatalog">Строка подключния</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        /// <exception cref="AccessViolationException"></exception>
        public async Task ConnectAsync(string initalCatalog, string login, string password) 
        {
            //OleDbConnectionStringBuilder connectionString = new OleDbConnectionStringBuilder()
            //{
            //    Provider = @"Microsoft.ACE.OLEDB.12.0",
            //    DataSource = $"{initalCatalog}",
            //};
            //await Task.Delay(5000);

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

        /// <summary>
        /// Создает запрос на отключения от источника данных
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync() 
        {
            if (_connection.State != 0) 
            {
                await _connection.CloseAsync();
            }
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения данных из таблицы
        /// </summary>
        /// <returns>Таблица данных о покупателях</returns>
        public async Task<IEnumerable<Customer>> GetTableAsync()
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

        /// <summary>
        /// Создает запрос на выполения команды в источнике данных
        /// </summary>
        /// <param name="command">Команда для выполения</param>
        /// <returns></returns>
        public async Task RunCommandAsync(string command)
        {
            OleDbCommand cmd = new OleDbCommand(command, _connection);
            await cmd.ExecuteNonQueryAsync();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
