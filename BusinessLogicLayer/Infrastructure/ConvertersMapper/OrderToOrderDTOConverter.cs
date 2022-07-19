using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Infrastructure.ConvertersMapper
{
    internal class OrderToOrderDTOConverter : ITypeConverter<Order, OrderDTO>
    {
        public OrderDTO Convert(Order source, OrderDTO destination, ResolutionContext context)
        {
            return new OrderDTO()
            {
                UID = source.UID,
                Email = source.EmailCustomer,
                Atricle = source.Atricle,
                NameProduct = source.NameProduct
            };
        }
    }
}
