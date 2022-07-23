using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    internal class PropertyCustomerDialog : IPropertyCustomerDialog
    {
        private readonly PropertyCustomerWindow _window;

        public PropertyCustomerDialog()
        {
            _window = new PropertyCustomerWindow();
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
