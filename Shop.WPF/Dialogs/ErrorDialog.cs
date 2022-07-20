using Shop.WPF.Interfaces.Dialogs;
using System.Windows;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Фунционал работы с диалоговым окном ошибки
    /// </summary>
    internal class ErrorDialog : IErrorDialog
    {
        /// <summary>
        /// Открывает новое диалоговое окно с ошибкой
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowDialog(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
