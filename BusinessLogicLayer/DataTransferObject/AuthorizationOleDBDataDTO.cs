namespace BusinessLogicLayer.DataTransferObject
{
    /// <summary>
    /// Класс для передачи данных для подключения к Access DB
    /// </summary>
    public record class AuthorizationOleDBDataDTO : BaseAuthorizationDB
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string? Login { get; init; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; init; }
    }
}
