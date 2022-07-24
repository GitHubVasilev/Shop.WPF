using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;

namespace Shop.WPF.ViewModel
{
    internal class DataSourceConnectOleDBVM : DataSourceConnectVM<AuthorizationOleDBDataDTO>
    {
        public DataSourceConnectOleDBVM(IAuthorizationService<AuthorizationOleDBDataDTO> serviceAuthorization,
           IDialogsConteiner conteinerDialogs) : base(serviceAuthorization, conteinerDialogs)
        {
        }

        public override RelayCommand? ConnectCommand
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {            
                IAuthorizationOleDBDialog dialog = _dialogsConteiner.AuthorizationOleDBDialog;
                DataSourceName = "Loading...";
                dialog.ShowDialog();
                if (dialog.ResultDialog()) 
                {
                    DataSourceName = "";
                }
            }, _ => IsConnect == 0);
        }
    }
}
