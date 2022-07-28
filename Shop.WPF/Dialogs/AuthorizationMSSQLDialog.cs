﻿using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.View;

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
