using BusinessLogicLayer.DataTransferObject.Entitys;

namespace BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс для сервисов обработки данных
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public interface IService<T>
        where T : BaseEntityDTO
    {
        delegate void NotifyUpdate(IService<T> sender, object? eventArgs);
        /// <summary>
        /// Событие об изменении данных
        /// </summary>
        public event NotifyUpdate? NotifyUpdateData;
        /// <summary>
        /// Асихронный метод возвращающий список данных
        /// </summary>
        /// <returns>Список запрошенных данных</returns>
        Task<List<T>> GetAsync();
        /// <summary>
        /// Асинхронный метод возвращающий список данных отфильтрованных по ключу 
        /// </summary>
        /// <param name="email">Ключ для фильтрации</param>
        /// <returns>список отфильтрованных данных</returns>
        Task<List<T>> GetAsync(string email);
        /// <summary>
        /// Асинхронный метод для создания записи в источнике данных
        /// </summary>
        /// <param name="entity">запись для добавления</param>
        /// <returns>Асинхронная задача</returns>
        Task CreateAsync(T entity);
        /// <summary>
        /// Асинхронный метод для обновления данных обновления записи
        /// </summary>
        /// <param name="entity">Запись для обновления</param>
        /// <returns>Асинхронная задача</returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Асинхронный метод для удаления записи
        /// </summary>
        /// <param name="entity">Запись для удаления</param>
        /// <returns>Асинхронная задача</returns>
        Task DeleteAsync(T entity);
        /// <summary>
        /// Асинхронный метод для очистки источника данных
        /// </summary>
        /// <returns></returns>
        Task CrearAsync();
    }
}
