using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;
using Shop.WPF.ViewModel;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна Авторизации пользователя в системе MS SQL
    /// </summary>
    internal class AuthorizationMSSQLDialog : IAuthorizationMSSQLDialog
    {
        private readonly AuthorizationMSSQLWindow _dialog;

        public AuthorizationMSSQLDialog()
        {
            _dialog = new();
            _dialog.DataContext = new AuthorizationMSSQLDataVM();
        }

        /// <summary>
        /// Данные для авторизации в системе MS SQL
        /// </summary>
        public AuthorizationMSSQLDataVM DataFromAuthorization => 
            (_dialog.DataContext as AuthorizationMSSQLDataVM) ?? new AuthorizationMSSQLDataVM();

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
