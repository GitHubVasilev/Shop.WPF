using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    /// <summary>
    /// Класс для упралвения источником данных о Заказах
    /// </summary>
    internal class OrderMSSQLContext : IMSSQLContext<Order>, IDisposable
    {
        private readonly SqlConnection _connection;

        public OrderMSSQLContext()
        {
            _connection = new();
        }

        /// <summary>
        /// Статус подключения. True - подключено, False - отключено
        /// </summary>
        public bool IsEnabled => _connection.State > 0;

        /// <summary>
        /// Строка подключения
        /// </summary>
        public string DatabaseName => _connection.Database;

        /// <summary>
        /// Создает запрос на подключения к источнику данных
        /// </summary>
        /// <param name="initialCatalog">Строка подключния</param>
        /// <returns></returns>
        /// <exception cref="AccessViolationException"></exception>
        public async Task ConnectAsync(string initialCatalog)
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

        /// <summary>
        /// Создает запрос на отключения от источника данных
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            if (!(_connection.State == 0)) 
            {
                await _connection.CloseAsync();
            }    
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения данных из таблицы
        /// </summary>
        /// <returns>Таблица данных о заказах</returns>
        public async Task<IEnumerable<Order>> GetTableAsync()
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

        /// <summary>
        /// Создает запрос на выполения команды в источнике данных
        /// </summary>
        /// <param name="command">Команда для выполения</param>
        /// <returns></returns>
        public async Task RunCommandAsync(string command)
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
