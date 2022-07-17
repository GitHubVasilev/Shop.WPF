using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    internal class CustomersRepository : IRepository<Customer>
    {
        private IOleDBContext<Customer> _dbContext;

        public CustomersRepository(IOleDBContext<Customer> oleDBContext)
        {
            _dbContext = oleDBContext;
        }

        public void Clear()
        {
            _dbContext.RunCommand("DELETE FROM Customers");
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            return _dbContext.GetTable();
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> predicate)
        {
            return _dbContext.GetTable().Where(predicate);
        }

        public void Insert(Customer entity)
        {
            _dbContext.RunCommand(
            "INSERT INTO Customers (Name, LastName, Patronymic, Phone, Email, UID)" +
            $"VALUES('{entity.Name}', '{entity.LastName}', '{entity.Patronymic}', '{entity.Phone}', '{entity.Email}', '{entity.UID}')");
        }

        public void Update(Customer entity)
        {
            _dbContext.RunCommand
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
