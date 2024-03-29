﻿using Shop.WPF.ViewModel;

namespace Shop.WPF.Interfaces.Dialogs
{
    /// <summary>
    /// Интерфейс авторизации пользователя в источнике данных MS Access
    /// </summary>
    internal interface IAuthorizationOleDBDialog : IAuthorizationDBDialog
    {
        AuthorizationOleDBDataVM DataFromAuthorization { get; }
    }
}
