using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна Добавления покупателя
    /// </summary>
    internal class AddCustomerDialog : IAddCustomerDialog
    {
        private readonly AddCustomerWindow _window;

        public AddCustomerDialog()
        {
            _window = new AddCustomerWindow();
        }

        /// <summary>
        /// Результат выполнения диалогового окна
        /// </summary>
        /// <returns>
        /// True - пользователь подтвердил действие
        /// False - пользователь отказался от выполнения
        /// </returns>
        public bool ResultDialog()
        {
            return _window.DialogResult ?? false;
        }

        /// <summary>
        /// Открывает диалоговое окно
        /// </summary>
        public void ShowDialog()
        {
            _window.ShowDialog();
        }
    }
}
