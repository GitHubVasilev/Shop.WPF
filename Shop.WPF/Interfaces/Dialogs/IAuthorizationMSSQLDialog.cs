﻿using Shop.WPF.ViewModel;

namespace Shop.WPF.Interfaces.Dialogs
{
    /// <summary>
    /// Интерфейс авторизации пользователя в источнике данных MS MSQ
    /// </summary>
    internal interface IAuthorizationMSSQLDialog : IAuthorizationDBDialog
    {
        AuthorizationMSSQLDataVM DataFromAuthorization { get; }
    }
}
