using AutoMapper;
using BusinessLogicLayer.DataTransferObject.Entitys;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Infrastructure.ConvertersMapper
{
    /// <summary>
    /// Automapper конвертер ДТО Покупателя в модель Покупателя
    /// </summary>
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
