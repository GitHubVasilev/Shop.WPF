using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Interfaces;
using Shop.WPF.ViewModel.Base;

namespace Shop.WPF.ViewModel
{
    internal class DataSourceConnectOleDBVM : DataSourceConnectVM<AuthorizationOleDBDataDTO>
    {
        public DataSourceConnectOleDBVM(IAuthorizationService<AuthorizationOleDBDataDTO> serviceAuthorization,
            IAuthorizationOleDBDialog dialog,
            IErrorDialog errorDialog) : base(serviceAuthorization, dialog, errorDialog)
        {
        }
    }
}
