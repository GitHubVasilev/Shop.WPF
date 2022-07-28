using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel
{
    /// <summary>
    /// Модель предстваления для авторизации в источнике данных MS Access
    /// </summary>
    internal class AuthorizationOleDBDataVM : ValidationBaseViewModel
    {
        private readonly IAuthorizationService<AuthorizationOleDBDataDTO> _serviceConnectDB;
        private readonly IDialogsConteiner _dialogConteiner;

        public AuthorizationOleDBDataVM(IAuthorizationService<AuthorizationOleDBDataDTO> serviceConnectDB, IDialogsConteiner dialogConteiner)
        {
            _serviceConnectDB = serviceConnectDB;
            _dialogConteiner = dialogConteiner;
        }

        private string? _dataSourceName;
        /// <summary>
        /// Строка подключения
        /// </summary>
        [Required(ErrorMessage = "Not Empty")]
        public string? DataSourceName
        {
            get => _dataSourceName;
            set => Set(ref _dataSourceName, value, nameof(DataSourceName));
        }

        private string? _login;
        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "Not Empty")]
        public string? Login 
        {
            get => _login;
            set => Set(ref _login, value, nameof(Login));
        }

        private string? _password;
        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Not Empty")]
        public string? Password 
        {
            get => _password;
            set => Set(ref _password, value, nameof(Password));
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
                    await _serviceConnectDB.ConnectAsync(new AuthorizationOleDBDataDTO()
                    {
                        DataSourceName = DataSourceName,
                        Login = Login,
                        Password = Password
                    });
                }
                catch (System.Exception e)
                {
                    _dialogConteiner.ErrorDialog.ShowDialog(e.Message);
                }
                       
            }, _ => !this.HasErrors);
        }
    }
}
