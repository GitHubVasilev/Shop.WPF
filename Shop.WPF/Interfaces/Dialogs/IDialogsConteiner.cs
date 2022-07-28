namespace Shop.WPF.Interfaces.Dialogs
{
    /// <summary>
    /// Интерфейс для собирательного класса диалоговых окон
    /// </summary>
    internal interface IDialogsConteiner
    {
        /// <summary>
        /// Интерфейс диалогового окна для авторизации пользователя в системе MS Access
        /// </summary>
        IAuthorizationOleDBDialog AuthorizationOleDBDialog { get; }
        /// <summary>
        /// Интерфейс диалогового окна для авторизации пользователя в системе MS SQL
        /// </summary>
        IAuthorizationMSSQLDialog AuthorizationMSSQLDialog { get; }
        /// <summary>
        /// Интерфейс диалогового окна с сообщением об ошибке
        /// </summary>
        IErrorDialog ErrorDialog { get; }
        /// <summary>
        /// Интерфейс диалогового окна с предупреждающим сообщением
        /// </summary>
        IWarningDialog WarningDialog { get; }
        /// <summary>
        /// Интерфейс диалогового окна для добавления нового покупателя
        /// </summary>
        IAddCustomerDialog AddCustomerDialog { get; }
        /// <summary>
        /// Интерфейс дмалогового окна для добавления нового заказа
        /// </summary>
        IAddOrderDialog AddOrderDialog { get; }
        /// <summary>
        /// Интерфейс дмалогового окна с информацией о покупателе
        /// </summary>
        IPropertyCustomerDialog PropertyCustomerDialog { get; }
        /// <summary>
        /// Интерфейс диалогового окна с информационным сообщением
        /// </summary>
        IMessageDialog MessageDialog { get; }
    }
}
