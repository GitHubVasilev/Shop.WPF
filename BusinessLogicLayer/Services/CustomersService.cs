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
        private IMapper _mapper;

        public CustomersService(IUnitOfWork uof, IMapperFactory mapperFactory)
        {
            _repository = uof.Customers;
            _mapper = mapperFactory.CustomerMapper;
        }

        public void Create(CustomerDTO entity)
        {
            _repository.Insert(_mapper.Map<Customer>(entity));
        }

        public void Delete(CustomerDTO entity)
        {
            _repository.Delete(_mapper.Map<Customer>(entity));
        }

        public List<CustomerDTO> Get()
        {
            return new List<CustomerDTO>(_mapper.Map<List<CustomerDTO>>(_repository.Get()));
        }

        public List<CustomerDTO> Get(string email)
        {
            return new List<CustomerDTO>(_mapper.Map<List<CustomerDTO>>(_repository.Get(m=>m.Email == email)));
        }

        public void Update(CustomerDTO entity)
        {
            _repository.Update(_mapper.Map<Customer>(entity));
        }
    }
}
