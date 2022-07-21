namespace Shop.WPF.Interfaces.Dialogs
{
    internal interface IErrorDialog
    {
        /// <summary>
        /// Создает новое диалоговое окно с сообщение об ошибке
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        void ShowDialog(string message);
    }
}
