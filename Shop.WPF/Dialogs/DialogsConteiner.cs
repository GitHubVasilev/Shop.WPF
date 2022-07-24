﻿using Shop.WPF.Interfaces.Dialogs;

namespace Shop.WPF.Dialogs
{
    internal class DialogsConteiner : IDialogsConteiner
    {
        public IAuthorizationOleDBDialog AuthorizationOleDBDialog => new AuthorizationOleDBDialog();

        public IAuthorizationMSSQLDialog AuthorizationMSSQLDialog => new AuthorizationMSSQLDialog();

        public IErrorDialog ErrorDialog => new ErrorDialog();

        public IWarningDialog WarningDialog => new WarningDialog();

        public IAddCustomerDialog AddCustomerDialog => new AddCustomerDialog();

        public IAddOrderDialog AddOrderDialog => new AddOrderDialog();

        public IPropertyCustomerDialog PropertyCustomerDialog => new PropertyCustomerDialog();

        public IMessageDialog MessageDialog => new MessageDialog();
    }
}