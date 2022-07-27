namespace BusinessLogicLayer.DataTransferObject
{
    /// <summary>
    /// Данные о поключении
    /// </summary>
    public record DataConnectionDBDTO
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        public string? DataSourceName { get; init; }
        /// <summary>
        /// Флаг активности поключения:
        /// True - подключено
        /// False - отключено
        /// </summary>
        public bool? IsConnect { get; init; }
    }
}
