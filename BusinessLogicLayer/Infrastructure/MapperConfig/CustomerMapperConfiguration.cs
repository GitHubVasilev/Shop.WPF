using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Infrastructure.ConvertersMapper;
using DataAccessLayer.Entities;


namespace BusinessLogicLayer.Infrastructure.MapperConfig
{
    /// <summary>
    /// Конфигурация конвертера <see cref="AutoMapper"/>  для Покупателей
    /// </summary>
    internal class CustomerMapperConfiguration : Profile
    {
        public CustomerMapperConfiguration()
        {
            CreateMap<CustomerDTO, Customer>()
                .ConvertUsing<CustomerDTOToModelConverter>();
            CreateMap<Customer, CustomerDTO>()
                .ConvertUsing<CustomerToCustomerDTOConverter>();
        }
    }
}
