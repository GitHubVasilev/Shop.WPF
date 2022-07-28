using Shop.WPF.Interfaces.Dialogs;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Собирательный класс для диалоговых окон
    /// </summary>
    internal class DialogsConteiner : IDialogsConteiner
    {
        /// <summary>
        /// Класс диалогового окна для авторизации пользователя в системе MS Access 
        /// </summary>
        public IAuthorizationOleDBDialog AuthorizationOleDBDialog => new AuthorizationOleDBDialog();

        /// <summary>
        /// Класс диалогового окна для авторизации пользователя в системе MS SQL 
        /// </summary>
        public IAuthorizationMSSQLDialog AuthorizationMSSQLDialog => new AuthorizationMSSQLDialog();

        /// <summary>
        /// Класс диалогового окна для вывода сообщения об ошибке
        /// </summary>
        public IErrorDialog ErrorDialog => new ErrorDialog();

        /// <summary>
        /// Класс диалогового окна для вывода предупреждающего сообщения
        /// </summary>
        public IWarningDialog WarningDialog => new WarningDialog();

        /// <summary>
        /// Класс диалогового окна для добавления нового Покупателя
        /// </summary>
        public IAddCustomerDialog AddCustomerDialog => new AddCustomerDialog();

        /// <summary>
        /// Класс диалогового окна для добавления нового Заказа
        /// </summary>
        public IAddOrderDialog AddOrderDialog => new AddOrderDialog();

        /// <summary>
        /// Класс диалогового окна Свойств покупателя
        /// </summary>
        public IPropertyCustomerDialog PropertyCustomerDialog => new PropertyCustomerDialog();

        /// <summary>
        /// Класс диалогового окна для вывода информационного сообщения
        /// </summary>
        public IMessageDialog MessageDialog => new MessageDialog();
    }
}
