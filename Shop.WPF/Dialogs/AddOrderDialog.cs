using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    internal class AddOrderDialog : IAddOrderDialog
    {
        private readonly AddOrderWindow _window;

        public AddOrderDialog()
        {
            _window = new AddOrderWindow();
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
