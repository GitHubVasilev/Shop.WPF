using System;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Модель покупателя
    /// </summary>
    public record class Customer : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; init; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; init; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; init; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; init; }
        /// <summary>
        /// Емейл
        /// </summary>
        public string? Email { get; init; }
    }
}
