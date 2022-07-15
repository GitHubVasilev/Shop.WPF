namespace Shop.WPF.Interfaces
{
    internal interface IBaseDialog
    {
        /// <summary>
        /// Метод создания нового диалогового окна
        /// </summary>
        void ShowDialog();
        /// <summary>
        /// Результат выполнения диалога
        /// </summary>
        /// <returns>
        ///     True - если пользователь подтвердил выполнение.
        ///     False - если пользователь просто закрыл окно
        /// </returns>
        bool ResultDialog();
    }
}
