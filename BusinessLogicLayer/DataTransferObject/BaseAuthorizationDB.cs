namespace BusinessLogicLayer.DataTransferObject
{
    /// <summary>
    /// Базовый класс для передачи данных для подключения к источнику данных
    /// </summary>
    public record BaseAuthorizationDB
    {
        /// <summary>
        /// Строка для подключения
        /// </summary>
        public string? DataSourceName { get ;init; }
    }
}
