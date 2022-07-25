using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;

namespace Shop.WPF.ViewModel
{
    internal class DataSourceConnectMSSQLVM : DataSourceConnectVM<AuthorizationMSSQLDataDTO>
    {
        public DataSourceConnectMSSQLVM(IAuthorizationService<AuthorizationMSSQLDataDTO> serviceAuthorization,
            IDialogsConteiner conteinerDialogs) : base(serviceAuthorization, conteinerDialogs)
        {
        }

        public override RelayCommand? ConnectCommand 
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {                
                IAuthorizationMSSQLDialog dialog = _dialogsConteiner.AuthorizationMSSQLDialog;
                
                dialog.ShowDialog();
                DataSourceName = "Loading...";

            }, _ => IsConnect == 0);
        }
    }
}
