using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна со свойствами покупателя
    /// </summary>
    internal class PropertyCustomerDialog : IPropertyCustomerDialog
    {
        private readonly PropertyCustomerWindow _window;

        public PropertyCustomerDialog()
        {
            _window = new PropertyCustomerWindow();
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
