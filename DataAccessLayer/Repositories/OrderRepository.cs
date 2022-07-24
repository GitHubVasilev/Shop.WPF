using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {
        private IMSSQLContext<Order> _dbContext;

        public OrderRepository(IMSSQLContext<Order> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Clear()
        {
            await _dbContext.RunCommand("EXEC deleteOrders");
        }

        public Task Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _dbContext.GetTable();
        }

        public async Task<IEnumerable<Order>> Get(Func<Order, bool> predicate)
        {
            return (await _dbContext.GetTable()).Where(predicate);
        }

        public async Task Insert(Order entity)
        {
            await _dbContext.RunCommand(
                "EXEC createOrder " +
                $"@UID='{entity.UID}', " +
                $"@email='{entity.EmailCustomer}', " +
                $"@article={entity.Atricle}, " +
                $"@nameProduct='{entity.NameProduct}'"
            );
        }

        public Task Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
