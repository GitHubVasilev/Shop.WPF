using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Repositories
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {

        private IRepository<Customer>? _customerRepository;
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
