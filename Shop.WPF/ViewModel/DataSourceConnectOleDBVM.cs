using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;

namespace Shop.WPF.ViewModel
{
    /// <summary>
    /// Модель представления инфомации об источнике данных MS Access
    /// </summary>
    internal class DataSourceConnectOleDBVM : DataSourceConnectVM<AuthorizationOleDBDataDTO>
    {
        public DataSourceConnectOleDBVM(IAuthorizationService<AuthorizationOleDBDataDTO> serviceAuthorization,
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
                IAuthorizationOleDBDialog dialog = _dialogsConteiner.AuthorizationOleDBDialog;

                dialog.ShowDialog();
                if (dialog.ResultDialog()) 
                {
                    DataSourceName = "Loading...";
                }
            }, _ => IsConnect == 0);
        }
    }
}
