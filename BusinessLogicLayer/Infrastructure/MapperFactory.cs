using AutoMapper;
using BusinessLogicLayer.Infrastructure.MapperConfig;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Infrastructure
{
    internal class MapperFactory : IMapperFactory
    {

        private IMapper? _mapperOrder;
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
