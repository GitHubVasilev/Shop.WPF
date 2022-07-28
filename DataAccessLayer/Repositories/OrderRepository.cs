using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класс для взаимодействия с источником данных с Заказами
    /// </summary>
    internal class OrderRepository : IRepository<Order>
    {
        private readonly IMSSQLContext<Order> _dbContext;

        public OrderRepository(IMSSQLContext<Order> dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Удаляет данные о всех заказах в источнике данных
        /// </summary>
        /// <returns></returns>
        public async Task ClearAsync()
        {
            await _dbContext.RunCommandAsync("EXEC deleteOrders");
        }

        /// <summary>
        /// Асинхронный метод создает запрос на удаления записи о заказе в источнике данных
        /// НЕ РЕАЛИЗОВАНО
        /// </summary>
        /// <param name="entity">Запись для удаления</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения данных о заказах
        /// </summary>
        /// <returns>Список заказов</returns>
        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _dbContext.GetTableAsync();
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения данных о заказах отфильтрованных по условию
        /// </summary>
        /// <param name="predicate">Условие для фильтрации</param>
        /// <returns>Список заказов</returns>
        public async Task<IEnumerable<Order>> GetAsync(Func<Order, bool> predicate)
        {
            return (await _dbContext.GetTableAsync()).Where(predicate);
        }

        /// <summary>
        /// Асинхронный метод создает запрос на добавление данных в источник данных
        /// </summary>
        /// <param name="entity">Запись для добваления</param>
        /// <returns></returns>
        public async Task InsertAsync(Order entity)
        {
            await _dbContext.RunCommandAsync(
                "EXEC createOrder " +
                $"@UID='{entity.UID}', " +
                $"@email='{entity.EmailCustomer}', " +
                $"@article={entity.Atricle}, " +
                $"@nameProduct='{entity.NameProduct}'"
            );
        }

        /// <summary>
        /// Асинхронный метод создает запрос на обновление записи в источнике данных
        /// НЕ РЕАЛИЗОВАН
        /// </summary>
        /// <param name="entity">Запись для обновления</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
