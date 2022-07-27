using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    /// <summary>
    /// Интрефейс классов взаимодействия с источником данных MS SQL
    /// </summary>
    /// <typeparam name="T">Модель которая описывает источник данных</typeparam>
    public interface IMSSQLContext<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Асинхронный метод создает запрос на подключения к источнику данных
        /// </summary>
        /// <param name="initialCatalog">Строка подключения к источнику данных</param>
        /// <returns></returns>
        Task ConnectAsync(string initialCatalog);
        /// <summary>
        /// Асинхронный метод создает запрос на отключения от источника данных
        /// </summary>
        /// <returns></returns>
        Task DisconnectAsync();
        /// <summary>
        /// Статус подключения. True - подключено, False - отключено
        /// </summary>
        bool IsEnabled { get; }
        /// <summary>
        /// Строка подключения
        /// </summary>
        string DatabaseName { get; }
        /// <summary>
        /// Асинхронный метод создает запрос на получения данных из источника
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetTableAsync();
        /// <summary>
        /// Асинхронный метод создает запрос на выполнение команды
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        /// <returns></returns>
        Task RunCommandAsync(string command);
    }
}
