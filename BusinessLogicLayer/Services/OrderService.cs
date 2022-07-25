using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IService<OrderDTO>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uof, IMapperFactory mapperFactory)
        {
            _repository = uof.Orders;
            _mapper = mapperFactory.OrderMapper;
        }

        public async Task Crear()
        {
            await _repository.Clear();
        }

        public async Task Create(OrderDTO entity)
        {
            await _repository.Insert(_mapper.Map<Order>(entity));
        }

        public async Task Delete(OrderDTO entity)
        {
            await _repository.Delete(_mapper.Map<Order>(entity));
        }

        public async Task<List<OrderDTO>> Get()
        {
            return new(_mapper.Map<List<OrderDTO>>(await _repository.Get()));
        }

        public async Task<List<OrderDTO>> Get(string email)
        {
            return _mapper.Map<List<OrderDTO>>(await _repository.Get(m => email == m.EmailCustomer));
        }

        public async Task Update(OrderDTO entity)
        {
            await _repository.Update(_mapper.Map<Order>(entity));
        }
    }
}
