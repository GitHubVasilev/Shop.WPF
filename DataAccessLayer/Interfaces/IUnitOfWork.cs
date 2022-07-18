using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IMSSQLContext<Order> OrdersConnect { get; }
        IOleDBContext<Customer> CustomrsConnect { get; }
    }
}
