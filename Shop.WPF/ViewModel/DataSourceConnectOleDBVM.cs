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
        /// Создает запрос на подключение к источнику данных
        /// </summary>
        public override RelayCommand? ConnectCommand
        {
            get => _connectCommand ??= new RelayCommand(async obj =>
            {            
                IAuthorizationOleDBDialog dialog = _dialogsConteiner.AuthorizationOleDBDialog;

                dialog.ShowDialog();
                if (dialog.ResultDialog()) 
                {
                    DataSourceName = "Loading...";

                    try
                    {
                        await _authorizationService.ConnectAsync(dialog.DataFromAuthorization.BaseModel);
                    }
                    catch (Exception e) 
                    {
                        _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                    }
                    
                    UpdateStatus(_authorizationService.GetStatusConnect());
                }
            }, _ => IsConnect == 0);
        }
    }
}
