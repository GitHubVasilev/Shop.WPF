using Shop.WPF.Interfaces.Dialogs;
using System.Windows;

namespace Shop.WPF.Dialogs
{
    internal class MessageDialog : IMessageDialog
    {
        public void ShowDialog(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
