using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Infrastructure.ConvertersMapper
{
    /// <summary>
    /// Automapper конвертер модель Покупателя в ДТО Покупателя
    /// </summary>
    internal class CustomerToCustomerDTOConverter : ITypeConverter<Customer, CustomerDTO>
    {
        public CustomerDTO Convert(Customer source, CustomerDTO destination, ResolutionContext context)
        {
            return new CustomerDTO()
            {
                UID = source.UID,
                Name = source.Name,
                LastName = source.LastName,
                Patronymic = source.Patronymic,
                Email = source.Email,
                Phone = source.Phone
            };
        }
    }
}
