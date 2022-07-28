namespace Shop.WPF.Interfaces.Dialogs
{
    /// <summary>
    /// ИНтрефейс класса дамлогового окна с сообщением об ошибке
    /// </summary>
    internal interface IWarningDialog
    {
        /// <summary>
        /// Результат выполнения диалогового окна
        /// </summary>
        /// <returns>
        /// True - пользователь подтвердил действие
        /// False - пользователь отказался от выполнения
        /// </returns>
        bool? ResultDialog();

        /// <summary>
        /// Открывает диалоговое окно
        /// </summary>
        /// <param name="message">Предупреждающее сообщения на диалоговом окне</param>
        void ShowDialog(string message);
    }
}
