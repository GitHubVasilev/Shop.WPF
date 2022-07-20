using AutoMapper;

namespace BusinessLogicLayer.Interfaces
{
    public interface IMapperFactory
    {
        IMapper OrderMapper { get; }
        IMapper CustomerMapper { get; }
    }
}
