using Shop.WPF.Interfaces;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    internal class AuthorizationOleDBDialog : IAuthorizationOleDBDialog
    {
        private readonly AuthorizationOleBDWindow _dialog;

        public AuthorizationOleDBDialog()
        {
            _dialog = new();
        }

        public bool ResultDialog()
        {
            return _dialog.DialogResult ?? false;
        }

        public void ShowDialog()
        {
            _dialog.Activate();
        }
    }
}
