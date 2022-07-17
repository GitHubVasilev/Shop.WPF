using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {
        private IMSSQLContext<Order> _dbContext;

        public OrderRepository(IMSSQLContext<Order> dbContext)
        {
            _dbContext = dbContext;
        }

        public void Clear()
        {
            _dbContext.RunCommand("EXEC deleteOrders");
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get()
        {
            return _dbContext.GetTable();
        }

        public IEnumerable<Order> Get(Func<Order, bool> predicate)
        {
            return _dbContext.GetTable().Where(predicate);
        }

        public void Insert(Order entity)
        {
            _dbContext.RunCommand(
                "EXEC createOrder " +
                $"@UID='{entity.UID}', " +
                $"@email='{entity.EmailCustomer}', " +
                $"@article={entity.Atricle}, " +
                $"@nameProduct='{entity.NameProduct}'"
            );
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
