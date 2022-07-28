using Shop.WPF.Interfaces.Dialogs;
using System.Windows;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна с предупреждающим сообщением
    /// </summary>
    internal class WarningDialog : IWarningDialog
    {
        private bool? _resultDialog;

        /// <summary>
        /// Результат выполнения диалогового окна
        /// </summary>
        /// <returns>
        /// True - пользователь подтвердил действие
        /// False - пользователь отказался от выполнения
        /// </returns>
        public bool? ResultDialog() 
        {
            return _resultDialog;
        }

        /// <summary>
        /// Открывает диалоговое окно
        /// </summary>
        /// <param name="message">Предупреждающее сообщения на диалоговом окне</param>
        public void ShowDialog(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Be careful!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            _resultDialog = result == MessageBoxResult.Yes;
        }
    }
}
