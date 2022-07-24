using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class CustomersRepository : IRepository<Customer>
    {
        private IOleDBContext<Customer> _dbContext;

        public CustomersRepository(IOleDBContext<Customer> oleDBContext)
        {
            _dbContext = oleDBContext;
        }

        public async Task Clear()
        {
            await _dbContext.RunCommand("DELETE FROM Customers");
        }

        public Task Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _dbContext.GetTable();
        }

        public async Task<IEnumerable<Customer>> Get(Func<Customer, bool> predicate)
        {
            return (await _dbContext.GetTable()).Where(predicate);
        }

        public async Task Insert(Customer entity)
        {
            await _dbContext.RunCommand(
            "INSERT INTO Customers (Name, LastName, Patronymic, Phone, Email, UID)" +
            $"VALUES('{entity.Name}', '{entity.LastName}', '{entity.Patronymic}', '{entity.Phone}', '{entity.Email}', '{entity.UID}')");
        }

        public async Task Update(Customer entity)
        {
            await _dbContext.RunCommand
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
