using Shop.WPF.Interfaces.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WPF.Dialogs
{
    internal class DialogsConteiner : IDialogsConteiner
    {
        public IAuthorizationOleDBDialog AuthorizationOleDBDialog => new AuthorizationOleDBDialog();

        public IAuthorizationMSSQLDialog AuthorizationMSSQLDialog => new AuthorizationMSSQLDialog();

        public IErrorDialog ErrorDialog => new ErrorDialog();
    }
}
