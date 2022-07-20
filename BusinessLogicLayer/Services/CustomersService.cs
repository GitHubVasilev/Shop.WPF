using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CustomersService : IService<CustomerDTO>
    {
        private IRepository<Customer> _repository;

        public CustomersService(IUnitOfWork uof)
        {
            _repository = uof.Customers;
        }

        public void Create(CustomerDTO entity)
        {
            _repository.Insert(entity)
        }

        public void Delete(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDTO> Get()
        {
            throw new NotImplementedException();
        }

        public List<CustomerDTO> Get(string email)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
