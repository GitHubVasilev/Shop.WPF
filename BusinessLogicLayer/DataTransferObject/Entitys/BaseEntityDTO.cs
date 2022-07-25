namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    /// <summary>
    /// Базовое класс для передачи данных
    /// </summary>
    public record class BaseEntityDTO 
    {
        /// <summary>
        /// Идентификатор - перчиный ключ
        /// </summary>
        public Guid UID { get; init; }
        /// <summary>
        /// Имейл (для сопоставления двух таблиц)
        /// </summary>
        public string? Email { get; init; }
    }
}
