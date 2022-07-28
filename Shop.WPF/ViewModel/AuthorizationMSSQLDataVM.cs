using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel
{
    /// <summary>
    /// Модель предстваления для авторизации в источнике данных MS SQL
    /// </summary>
    internal class AuthorizationMSSQLDataVM : ValidationBaseViewModel
    {
        private readonly IAuthorizationService<AuthorizationMSSQLDataDTO> _serviceConnectDB;
        private readonly IDialogsConteiner _dialogConteiner;

        public AuthorizationMSSQLDataVM(IAuthorizationService<AuthorizationMSSQLDataDTO> serviceConnectDB, IDialogsConteiner dialogConteiner)
        {
            _serviceConnectDB = serviceConnectDB;
            _dialogConteiner = dialogConteiner;
        }

        private string? _dataSourceName;
        /// <summary>
        /// Строка соединения
        /// </summary>
        [Required(ErrorMessage="Not Empty")]
        public string? DataSourceName 
        {
            get => _dataSourceName;
            set => Set(ref _dataSourceName, value, nameof(DataSourceName));
        }

        private RelayCommand? _connectCommand;
        /// <summary>
        /// Команда для подключения к источнику данных
        /// </summary>
        public RelayCommand ConnectCommand 
        {
            get => _connectCommand ??= new RelayCommand(async obj =>
            {
                try
                {
                    await _serviceConnectDB.ConnectAsync(new AuthorizationMSSQLDataDTO() { DataSourceName = DataSourceName });
                }
                catch (Exception e) 
                {
                    _dialogConteiner.ErrorDialog.ShowDialog(e.Message);
                }
            }, _ => !this.HasErrors);
        }
    }
}
