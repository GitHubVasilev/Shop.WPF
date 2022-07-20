using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces;
using System;

namespace Shop.WPF.ViewModel.Base
{
    internal abstract class DataSourceConnectVM<T> : BaseViewModel, IConnectionProvider<T>
        where T : BaseAuthorizationDB
    {
        private readonly IAuthorizationDBDialog _authorizationDBDialog;
        private readonly IAuthorizationService<T> _authorizationService;
        private IErrorDialog _errorDialog;

        public DataSourceConnectVM(IAuthorizationService<T> serviceAuthorization, IAuthorizationDBDialog dialog, IErrorDialog errorDialog)
        {
            _authorizationDBDialog = dialog;
            _authorizationService = serviceAuthorization;
            _errorDialog = errorDialog;
            DataSourceName = _authorizationService.GetStatusConnect().DataSourceName;
            IsConnect = Convert.ToInt32(_authorizationService.GetStatusConnect().IsConnected)
            _authorizationService.ConnectionEvent += ConnectionOrDisconnection;
            _authorizationService.DisconnectonEvent += ConnectionOrDisconnection;
        }

        private void ConnectionOrDisconnection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs)
        {
            OnPropertyChanged(nameof(DataSourceName));
            OnPropertyChanged(nameof(IsConnect));
        }

        private string? _dataSourceName;
        public string? DataSourceName
        {
            get => _dataSourceName;
            set 
            {
                _dataSourceName = value;
                OnPropertyChanged();
            }
        }

        private int _isConnect;
        public int IsConnect
        {
            get => _isConnect;
            set 
            {
                _isConnect = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _connectCommand;

        public RelayCommand? ConnectCommand
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {
                _authorizationDBDialog.ShowDialog();
            }, _ => IsConnect == 0);
        }

        private RelayCommand? _disconnectCommand;

        public RelayCommand? DisconnectCommand
        {
            get => _disconnectCommand ??= new RelayCommand(obj =>
            {
                try
                {
                    _authorizationService.Disconect();
                }
                catch (Exception e)
                {
                    _errorDialog.ShowDialog(e.Message);
                }
            }, _ => IsConnect == 1);
        }

        
    }
}
