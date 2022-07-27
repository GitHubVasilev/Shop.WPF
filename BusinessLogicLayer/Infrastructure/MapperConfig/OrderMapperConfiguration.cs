using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Infrastructure.ConvertersMapper;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Infrastructure.MapperConfig
{
    /// <summary>
    /// Конфигурация конвертера <see cref="AutoMapper"/>  для Заказов
    /// </summary>
    internal class OrderMapperConfiguration : Profile
    {
        public OrderMapperConfiguration()
        {
            CreateMap<OrderDTO, Order>()
                .ConvertUsing<OrderDTOToModelConverter>();
            CreateMap<Order, OrderDTO>()
                .ConvertUsing<OrderToOrderDTOConverter>();
        }
    }
}
