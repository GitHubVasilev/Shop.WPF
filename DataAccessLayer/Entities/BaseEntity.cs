using System;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Базовое представление сущности
    /// </summary>
    public record class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public Guid UID { get; init; }
    }
}
