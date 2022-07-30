using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;
using Shop.WPF.ViewModel;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна для авторизации пользователя в системе MS Access 
    /// </summary>
    internal class AuthorizationOleDBDialog : IAuthorizationOleDBDialog
    {
        private readonly AuthorizationOleBDWindow _dialog;

        public AuthorizationOleDBDialog()
        {
            _dialog = new();
            _dialog.DataContext = new AuthorizationOleDBDataVM();
        }

        /// <summary>
        /// Данные для авторизации в системе MS Access
        /// </summary>
        public AuthorizationOleDBDataVM DataFromAuthorization =>
            (_dialog.DataContext as AuthorizationOleDBDataVM) ?? new AuthorizationOleDBDataVM();

        /// <summary>
        /// Результат выполнения диалогового окна
        /// </summary>
        /// <returns>
        /// True - пользователь подтвердил действие
        /// False - пользователь отказался от выполнения
        /// </returns>
        public bool ResultDialog()
        {
            return _dialog.DialogResult ?? false;
        }

        /// <summary>
        /// Открывает диалоговое окно
        /// </summary>
        public void ShowDialog()
        {
            _dialog.ShowDialog();
        }
    }
}
