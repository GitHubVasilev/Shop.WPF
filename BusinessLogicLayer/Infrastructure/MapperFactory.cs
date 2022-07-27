using AutoMapper;
using BusinessLogicLayer.Infrastructure.MapperConfig;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Infrastructure
{
    /// <summary>
    /// Собирательный класс для объектов <see cref="IMapper"/>
    /// </summary>
    internal class MapperFactory : IMapperFactory
    {

        private IMapper? _mapperOrder;
        /// <summary>
        /// Маппер для Заказов 
        /// </summary>
        public IMapper OrderMapper 
        {
            get 
            {
                if (_mapperOrder is null) 
                {
                    MapperConfiguration mapperConfiguration = new(prof =>
                        prof.AddProfile<OrderMapperConfiguration>()
                    );
                    _mapperOrder = new Mapper(mapperConfiguration);
                }
                return _mapperOrder;
            }
        }

        private IMapper? _customerMapper;
        /// <summary>
        /// Маппер для Клиентов
        /// </summary>
        public IMapper CustomerMapper 
        {
            get 
            {
                if (_customerMapper is null) 
                {
                    MapperConfiguration mapperConfiguration = new(prof =>
                        prof.AddProfile<CustomerMapperConfiguration>()
                    );
                    _customerMapper = new Mapper(mapperConfiguration);
                }
                return _customerMapper;
            }
        }
    }
}
