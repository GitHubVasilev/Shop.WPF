using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    /// <summary>
    /// Интрефейс класса для взяимодействия с источником данных
    /// </summary>
    /// <typeparam name="T">Тип данных источника данных</typeparam>
    public interface IRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Асинхронный метод создает запрос на получения данных из источника
        /// </summary>
        /// <returns>Список полученных данных</returns>
        Task<IEnumerable<T>> GetAsync();
        /// <summary>
        /// Асинхронный метод создает запрос на получения данных из источника отфильтрованных по условию
        /// </summary>
        /// <param name="predicate">Условие для фильтрации</param>
        /// <returns>Список полученных данных</returns>
        Task<IEnumerable<T>> GetAsync(Func<T,bool> predicate);
        /// <summary>
        /// Асинхронный метод создает запрос на добавления данных в источник
        /// </summary>
        /// <param name="entity">Запись для добавления</param>
        /// <returns></returns>
        Task InsertAsync(T entity);
        /// <summary>
        /// Асинхронный метод создает запрос на обновление данных в источнике
        /// </summary>
        /// <param name="entity">Запись для обновления</param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Асинхронный методы создает запрос на удаления данных в источнике
        /// </summary>
        /// <param name="entity">Запись для удаления</param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
        /// <summary>
        /// Асинхронный методы создает запрос на удаления данных в источнике отфильтрованных по параметру
        /// </summary>
        /// <param name="email">параметр для удаления</param>
        /// <returns></returns>
        Task DeleteAsync(string email);
        /// <summary>
        /// Асинхронный метод создает запрос на удаление данных в источнике
        /// </summary>
        /// <returns></returns>
        Task ClearAsync();
    }
}
