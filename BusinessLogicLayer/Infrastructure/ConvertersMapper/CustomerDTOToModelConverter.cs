using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Infrastructure.ConvertersMapper
{
    internal class CustomerDTOToModelConverter : ITypeConverter<CustomerDTO, Customer>
    {
        public Customer Convert(CustomerDTO source, Customer destination, ResolutionContext context)
        {
            return new Customer() 
            {
                UID = source.UID,
                Name = source.Name,
                LastName = source.LastName,
                Patronymic = source.Patronymic,
                Email = source.Email,
                Phone = source.Phone,
            };
        }
    }
}
