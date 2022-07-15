using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Interfaces;
using Shop.WPF.ViewModel.Base;

namespace Shop.WPF.ViewModel
{
    internal class DataSourceConnectMSSQLVM : DataSourceConnectVM<AuthorizationMSSQLDataDTO>
    {
        public DataSourceConnectMSSQLVM(IAuthorizationService<AuthorizationMSSQLDataDTO> serviceAuthorization,
            IAuthorizationMSSQLDialog dialog,
            IErrorDialog errorDialog) : base(serviceAuthorization, dialog, errorDialog)
        {
        }
    }
}
