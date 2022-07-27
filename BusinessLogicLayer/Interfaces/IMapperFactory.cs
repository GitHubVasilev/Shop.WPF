using AutoMapper;

namespace BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс собирательного класса для конвертеров <see cref="AutoMapper"/>
    /// </summary>
    public interface IMapperFactory
    {
        /// <summary>
        /// Конвертер для данных Заказов
        /// </summary>
        IMapper OrderMapper { get; }
        /// <summary>
        /// Конвертер для данных Клиентов
        /// </summary>
        IMapper CustomerMapper { get; }
    }
}
