using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel
{
    internal class AuthorizationOleDBDataVM : ValidationBaseViewModel
    {
        private readonly IAuthorizationService<AuthorizationOleDBDataDTO> _serviceConnectDB;

        public AuthorizationOleDBDataVM(IAuthorizationService<AuthorizationOleDBDataDTO> serviceConnectDB)
        {
            _serviceConnectDB = serviceConnectDB;
        }

        private string? _dataSourceName;

        [Required(ErrorMessage = "Not Empty")]
        public string? DataSourceName
        {
            get => _dataSourceName;
            set => Set(ref _dataSourceName, value, nameof(DataSourceName));
        }

        private string? _login;

        [Required(ErrorMessage = "Not Empty")]
        public string? Login 
        {
            get => _login;
            set => Set(ref _login, value, nameof(Login));
        }

        private string? _password;

        [Required(ErrorMessage = "Not Empty")]
        public string? Password 
        {
            get => _password;
            set => Set(ref _password, value, nameof(Password));
        }

        private RelayCommand? _connectCommand;

        public RelayCommand ConnectCommand
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {
                _serviceConnectDB.Connect(new AuthorizationOleDBDataDTO()
                {
                    DataSourceName = DataSourceName,
                    Login = Login,
                    Password = Password
                });
            }, _ => !this.HasErrors);
        }
    }
}
