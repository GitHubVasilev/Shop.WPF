using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel
{
    internal class AuthorizationMSSQLDataVM : ValidationBaseViewModel
    {
        private readonly IAuthorizationService<AuthorizationMSSQLDataDTO> _serviceConnectDB;

        public AuthorizationMSSQLDataVM(IAuthorizationService<AuthorizationMSSQLDataDTO> serviceConnectDB)
        {
            _serviceConnectDB = serviceConnectDB;
        }

        private string? _dataSourceName;

        [Required(ErrorMessage="Not Empty")]
        public string? DataSourceName 
        {
            get => _dataSourceName;
            set => Set(ref _dataSourceName, value, nameof(DataSourceName));
        }

        private RelayCommand? _connectCommand;

        public RelayCommand ConnectCommand 
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {
                _serviceConnectDB.Connect(new AuthorizationMSSQLDataDTO() { DataSourceName = DataSourceName });
            }, _ => !this.HasErrors);
        }
    }
}
