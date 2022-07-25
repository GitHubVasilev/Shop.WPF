namespace BusinessLogicLayer.DataTransferObject
{
    /// <summary>
    /// Данные о поключении
    /// </summary>
    public record DataConnectionDBDTO
    {
        /// <summary>
        /// строка подключения
        /// </summary>
        public string? DataSourceName { get; init; }
        /// <summary>
        /// Флаг активности поключения:
        /// True - подключено
        /// False - отключено
        /// </summary>
        public bool? IsConnected { get; init; }
    }
}
