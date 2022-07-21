using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    internal class AddCustomerDialog : IAddCustomerDialog
    {
        private readonly AddCustomerWindow _window;

        public AddCustomerDialog()
        {
            _window = new AddCustomerWindow();
        }

        public bool ResultDialog()
        {
            return _window.DialogResult ?? false;
        }

        public void ShowDialog()
        {
            _window.ShowDialog();
        }
    }
}
