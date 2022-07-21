using Shop.WPF.Interfaces.Dialogs;
using System.Windows;

namespace Shop.WPF.Dialogs
{
    internal class WarningDialog : IWarningDialog
    {
        private bool? _resultDialog;

        public bool? ResultDialog() 
        {
            return _resultDialog;
        }

        public void ShowDialog(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Be careful!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            _resultDialog = result == MessageBoxResult.Yes;
        }
    }
}
