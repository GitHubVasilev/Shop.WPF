using Shop.WPF.Interfaces.Dialogs;
using System.Windows;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна для вывода информационного сообщения
    /// </summary>
    internal class MessageDialog : IMessageDialog
    {
        /// <summary>
        /// Показывает диалоговое окно
        /// </summary>
        /// <param name="message">Текст сообщения на диалоговом окне</param>
        public void ShowDialog(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
