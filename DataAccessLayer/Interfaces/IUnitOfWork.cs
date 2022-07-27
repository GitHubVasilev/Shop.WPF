using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    /// <summary>
    /// Интерфейс класса предоставляющего доступ к репозиториям
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Репозиторий покупателей
        /// </summary>
        IRepository<Customer> Customers { get; }
        /// <summary>
        /// Репозиторий заказов
        /// </summary>
        IRepository<Order> Orders { get; }
        /// <summary>
        /// Интерфейс класса для управления источником данных о заказах
        /// </summary>
        IMSSQLContext<Order> OrdersConnect { get; }
        /// <summary>
        /// Интерфейс класса для управления источником данных о покупателях
        /// </summary>
        IOleDBContext<Customer> CustomrsConnect { get; }
    }
}
