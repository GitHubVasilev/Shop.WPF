namespace Shop.WPF.Interfaces.Dialogs
{
    /// <summary>
    /// Интерфейс для диалогового окна с информационным сообщением
    /// </summary>
    internal interface IMessageDialog
    { 
        /// <summary>
        /// Выводит диалогове окно на экран
        /// </summary>
        /// <param name="message">Информационное сообщение на диалоговом окне</param>
        void ShowDialog(string message);
    }
}
