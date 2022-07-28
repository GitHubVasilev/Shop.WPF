using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

namespace Shop.WPF.Dialogs
{
    /// <summary>
    /// Класс диалогового окна Добавления нового заказа
    /// </summary>
    internal class AddOrderDialog : IAddOrderDialog
    {
        private readonly AddOrderWindow _window;

        public AddOrderDialog()
        {
            _window = new AddOrderWindow();
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
