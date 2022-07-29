using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класс для взаимодействия с источником данных с Покупателями
    /// </summary>
    internal class CustomersRepository : IRepository<Customer>
    {
        private IOleDBContext<Customer> _dbContext;

        public CustomersRepository(IOleDBContext<Customer> oleDBContext)
        {
            _dbContext = oleDBContext;
        }

        /// <summary>
        /// Асинхронный метод создает запрос на очистку источника данных
        /// </summary>
        /// <returns></returns>
        public async Task ClearAsync()
        {
            await _dbContext.RunCommandAsync("DELETE FROM Customers");
        }

        /// <summary>
        /// Асинхронный метод создает запрос на удаления данных покупателя из источника данных
        /// НЕ реализованно
        /// </summary>
        /// <param name="entity">Данные о покупателе</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Асинхронный метод создает запрос на удаления отфильтрованные данных покупателя
        /// НЕ реализованно
        /// </summary>
        /// <param name="email">Параметр для фильтрации</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteAsync(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения данных о покупателях
        /// </summary>
        /// <returns>Список покупателей</returns>
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _dbContext.GetTableAsync();
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получение данных о пользователях, отфильтровывает по условию
        /// </summary>
        /// <param name="predicate">Условия для фильтрации таблицы</param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAsync(Func<Customer, bool> predicate)
        {
            return (await _dbContext.GetTableAsync()).Where(predicate);
        }

        /// <summary>
        /// Асинхронный метод создает запрос на добавление данных о новом пользователе
        /// </summary>
        /// <param name="entity">данные для новой записи</param>
        /// <returns></returns>
        public async Task InsertAsync(Customer entity)
        {
            await _dbContext.RunCommandAsync(
            "INSERT INTO Customers (Name, LastName, Patronymic, Phone, Email, UID)" +
            $"VALUES('{entity.Name}', '{entity.LastName}', '{entity.Patronymic}', '{entity.Phone}', '{entity.Email}', '{entity.UID}')");
        }

        /// <summary>
        /// Асинхронный метод создает запрос об обновлении записи о покупателе в источнике данных
        /// </summary>
        /// <param name="entity">Обновленная запись</param>
        /// <returns></returns>
        public async Task UpdateAsync(Customer entity)
        {
            await _dbContext.RunCommandAsync
                (
                "UPDATE Customers" +
                " SET   " +
                     $"UID = '{entity.UID}'," +
                     $"Name = '{entity.Name}'," +
                     $"LastName = '{entity.LastName}'," +
                     $"Patronymic = '{entity.Patronymic}'," +
                     $"Phone = '{entity.Phone}'," +
                     $"Email = '{entity.Email}'" +
                     $"WHERE(Email = '{entity.Email}')"
                );
        }
    }
}
