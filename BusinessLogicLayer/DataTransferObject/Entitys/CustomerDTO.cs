namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    /// <summary>
    /// класс для передачи данных Покупателя
    /// </summary>
    public record class CustomerDTO : BaseEntityDTO
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
    }
}
