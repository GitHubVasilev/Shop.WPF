using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класса предоставляющего доступ к репозиториям
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private IRepository<Customer>? _customerRepository;
        /// <summary>
        /// Класс для взаимодействия с источником данных с Покупателями
        /// </summary>
        public IRepository<Customer> Customers 
        {
            get 
            {
                if (_customerRepository is null) 
                { _customerRepository = new CustomersRepository(CustomrsConnect); }
                return _customerRepository;
            }
        }

        private IRepository<Order>? _orderRepository;
        /// <summary>
        /// Класс для взаимодействия с источником данных с Заказами
        /// </summary>
        public IRepository<Order> Orders 
        {
            get 
            {
                if (_orderRepository is null) 
                { _orderRepository = new OrderRepository(OrdersConnect); }
                return _orderRepository;
            }
        }


        private IMSSQLContext<Order>? _ordersConnect;
        /// <summary>
        /// Класс для взаимодействия с источником данных с заказми
        /// </summary>
        public IMSSQLContext<Order> OrdersConnect
        {
            get 
            {
                if (_ordersConnect is null) 
                { _ordersConnect = new OrderMSSQLContext(); }
                return _ordersConnect;
            }
        }

        private IOleDBContext<Customer>? _customersContext;
        /// <summary>
        /// Класс для взаимодействия с источником данных с покупателями
        /// </summary>
        public IOleDBContext<Customer> CustomrsConnect 
        {
            get 
            {
                if (_customersContext is null) 
                { _customersContext = new CustomersOleDBContext(); }
                return _customersContext;
            }
        }

        public void Dispose()
        {
            ((IDisposable)Customers)?.Dispose();
            ((IDisposable)OrdersConnect)?.Dispose();
        }
    }
}
