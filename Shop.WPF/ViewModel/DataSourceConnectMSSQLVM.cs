using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;

namespace Shop.WPF.ViewModel
{
    /// <summary>
    /// Модель представления инфомации об источнике данных MS SQL
    /// </summary>
    internal class DataSourceConnectMSSQLVM : DataSourceConnectVM<AuthorizationMSSQLDataDTO>
    {
        public DataSourceConnectMSSQLVM(IAuthorizationService<AuthorizationMSSQLDataDTO> serviceAuthorization,
            IDialogsConteiner conteinerDialogs) : base(serviceAuthorization, conteinerDialogs)
        {
        }

        /// <summary>
        /// Команда вызывает диалогове окно для подключения к источнику данных
        /// </summary>
        public override RelayCommand? ConnectCommand 
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {                
                IAuthorizationMSSQLDialog dialog = _dialogsConteiner.AuthorizationMSSQLDialog;
                
                dialog.ShowDialog();
                if (dialog.ResultDialog())
                {
                    DataSourceName = "Loading...";
                }

            }, _ => IsConnect == 0);
        }
    }
}
