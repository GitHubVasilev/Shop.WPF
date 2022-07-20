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
            _mapper = mapperFactory.CustomerMapper;
        }

        public void Crear()
        {
            _repository.Clear();
        }

        public void Create(OrderDTO entity)
        {
            _repository.Insert(_mapper.Map<Order>(entity));
        }

        public void Delete(OrderDTO entity)
        {
            _repository.Delete(_mapper.Map<Order>(entity));
        }

        public List<OrderDTO> Get()
        {
            return new(_mapper.Map<List<OrderDTO>>(_repository.Get()));
        }

        public List<OrderDTO> Get(string email)
        {
            return new(_mapper.Map<List<OrderDTO>>(_repository.Get()));
        }

        public void Update(OrderDTO entity)
        {
            _repository.Update(_mapper.Map<Order>(entity));
        }
    }
}
