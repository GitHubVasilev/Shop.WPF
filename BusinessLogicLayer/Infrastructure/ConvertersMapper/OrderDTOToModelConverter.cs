using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Infrastructure.ConvertersMapper
{
    internal class OrderDTOToModelConverter : ITypeConverter<OrderDTO, Order>
    {
        public Order Convert(OrderDTO source, Order destination, ResolutionContext context)
        {
            return new Order() 
            {
                UID = source.UID,
                EmailCustomer = source.Email,
                Atricle = source.Atricle,
                NameProduct = source.NameProduct
            };
        }
    }
}
