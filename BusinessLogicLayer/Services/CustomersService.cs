using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class CustomersService : IService<CustomerDTO>
    {
        private IRepository<Customer> _repository;
        private IRepository<Order> _repositoryOrder;
        private IMapper _mapper;

        public CustomersService(IUnitOfWork uof, IMapperFactory mapperFactory)
        {
            _repository = uof.Customers;
            _mapper = mapperFactory.CustomerMapper;
            _repositoryOrder = uof.Orders;
        }

        public async Task Crear()
        {
            await _repositoryOrder.Clear();
            await _repository.Clear();  
        }

        public async Task Create(CustomerDTO entity)
        {
            await _repository.Insert(_mapper.Map<Customer>(entity));
        }

        public async Task Delete(CustomerDTO entity)
        {
            await _repository.Delete(_mapper.Map<Customer>(entity));
        }

        public async Task<List<CustomerDTO>> Get()
        {
            return new List<CustomerDTO>(_mapper.Map<List<CustomerDTO>>(await _repository.Get()));
        }

        public async Task<List<CustomerDTO>> Get(string email)
        {
            return new List<CustomerDTO>(_mapper.Map<List<CustomerDTO>>(await _repository.Get(m=>m.Email == email)));
        }

        public async Task Update(CustomerDTO entity)
        {
            await _repository.Update(_mapper.Map<Customer>(entity));
        }
    }
}
