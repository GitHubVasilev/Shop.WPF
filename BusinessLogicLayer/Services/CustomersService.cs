using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Сервис для обработки данных клиентов
    /// </summary>
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

        /// <summary>
        /// Событие о изменении данных после запроса сервиса
        /// </summary>
        public event IService<CustomerDTO>.NotifyUpdate? NotifyUpdateData;

        /// <summary>
        /// Асинхронный метод очищающий источник данных Очищает источник данных и связанные с ними данные
        /// </summary>
        /// <returns></returns>
        public async Task CrearAsync()
        {
            await _repositoryOrder.ClearAsync();
            await _repository.ClearAsync();  
        }

        /// <summary>
        /// Асинхронный метод создает запрос о создании записи
        /// </summary>
        /// <param name="entity">Запись для добавления</param>
        /// <returns></returns>
        public async Task CreateAsync(CustomerDTO entity)
        {
            await _repository.InsertAsync(_mapper.Map<Customer>(entity));
            NotifyUpdateData?.Invoke(this, null);
        }

        /// <summary>
        /// Асинхронный метод создает запрос для удаления записи из источника данных
        /// </summary>
        /// <param name="entity">запись для удаления</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"/>
        public async Task DeleteAsync(CustomerDTO entity)
        {
            if ((await _repository.GetAsync(m => entity.Email == m.Email)).Count() == 0)
            { throw new ArgumentException($"Entity with email {entity.Email} not find"); }
            await _repository.DeleteAsync(_mapper.Map<Customer>(entity));
            NotifyUpdateData?.Invoke(this, null);
        }

        /// <summary>
        /// Асинхронный метод создает запрос о получении данных
        /// </summary>
        /// <returns>Список полученных записей</returns>
        public async Task<List<CustomerDTO>> GetAsync()
        {
            return new List<CustomerDTO>(_mapper.Map<List<CustomerDTO>>(await _repository.GetAsync()));
        }

        /// <summary>
        /// Асинхронный метод создает запрос о получении данных. Отфильтровывает данные по полю email
        /// </summary>
        /// <param name="email">Email для фильтрации данных</param>
        /// <returns>Список полученных данных</returns>
        public async Task<List<CustomerDTO>> GetAsync(string email)
        {
            return new List<CustomerDTO>(_mapper.Map<List<CustomerDTO>>(await _repository.GetAsync(m=>m.Email == email)));
        }

        /// <summary>
        /// Асинхронный метод создает запрос на обновления данных
        /// </summary>
        /// <param name="entity">Запись для обновления</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task UpdateAsync(CustomerDTO entity)
        {
            if ((await _repository.GetAsync(m => entity.Email == m.Email)).Count() == 0)
            { throw new ArgumentException($"Entity with email {entity.Email} not find"); }
            await _repository.UpdateAsync(_mapper.Map<Customer>(entity));
            NotifyUpdateData?.Invoke(this, null);
        }
    }
}
