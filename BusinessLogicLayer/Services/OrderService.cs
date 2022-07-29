using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Сервис для работы с данными о Заказах
    /// </summary>
    public class OrderService : IService<OrderDTO>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uof, IMapperFactory mapperFactory)
        {
            _repository = uof.Orders;
            _mapper = mapperFactory.OrderMapper;
        }

        /// <summary>
        /// Событие для оповещения об изменении данных после запроса
        /// </summary>
        public event IService<OrderDTO>.NotifyUpdate? NotifyUpdateData;

        /// <summary>
        /// Асинхронный метод создает запрос на очистку источника данных
        /// </summary>
        /// <returns></returns>
        public async Task CrearAsync()
        {
            await _repository.ClearAsync();
            NotifyUpdateData?.Invoke(this, null);
        }

        /// <summary>
        /// Асинхронный методы создает запрос на создание новой записи
        /// </summary>
        /// <param name="entity">Запсиь для создания</param>
        /// <returns></returns>
        public async Task CreateAsync(OrderDTO entity)
        {
            await _repository.InsertAsync(_mapper.Map<Order>(entity));
            NotifyUpdateData?.Invoke(this, null);
        }

        /// <summary>
        /// Асинхронный метод создает запрос на удаления записи из источника данных
        /// </summary>
        /// <param name="entity">Запись для удаления</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task DeleteAsync(OrderDTO entity)
        {
            if ((await _repository.GetAsync(m => entity.Email == m.EmailCustomer)).Any())
            { throw new ArgumentException($"Entity with email {entity.Email} not find"); }
            await _repository.DeleteAsync(_mapper.Map<Order>(entity));
            NotifyUpdateData?.Invoke(this, null);
        }

        /// <summary>
        /// Асинхронный метод удаляет данные отфильтрованные по параметру
        /// </summary>
        /// <param name="email">Параметр для фильтрации</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(string email)
        {
            await _repository.DeleteAsync(email);
            NotifyUpdateData?.Invoke(this, null);
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения записей из источника данных
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderDTO>> GetAsync()
        {
            return new(_mapper.Map<List<OrderDTO>>(await _repository.GetAsync()));
        }

        /// <summary>
        /// Асинхронный метод создает запрос на получения записей из источника данных, отфильтрованных по полю
        /// </summary>
        /// <param name="email">данные для поля фильтрации</param>
        /// <returns></returns>
        public async Task<List<OrderDTO>> GetAsync(string email)
        {
            return _mapper.Map<List<OrderDTO>>(await _repository.GetAsync(m => email == m.EmailCustomer));
        }

        /// <summary>
        /// Обновляет данные о записи в источнике данных
        /// </summary>
        /// <param name="entity">Запиь для обновления</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task UpdateAsync(OrderDTO entity)
        {
            if ((await _repository.GetAsync(m => entity.Email == m.EmailCustomer)).Any())
            { throw new ArgumentException($"Entity with email {entity.Email} not find"); }
            await _repository.UpdateAsync(_mapper.Map<Order>(entity));
            NotifyUpdateData?.Invoke(this, null);
        }
    }
}
