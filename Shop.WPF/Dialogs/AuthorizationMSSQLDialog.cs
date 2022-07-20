using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    internal class AuthorizationMSSQLDialog : IAuthorizationMSSQLDialog
    {
        private readonly AuthorizationMSSQLWindow _dialog;

        public AuthorizationMSSQLDialog()
        {
            _dialog = new();
        }

        public bool ResultDialog()
        {
            return _dialog.DialogResult ?? false;
        }

        public void ShowDialog()
        {
            _dialog.ShowDialog();
        }
    }
}
