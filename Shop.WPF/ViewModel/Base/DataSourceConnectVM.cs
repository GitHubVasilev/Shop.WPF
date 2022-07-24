using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces;
using Shop.WPF.Interfaces.Dialogs;
using System;

namespace Shop.WPF.ViewModel.Base
{
    internal abstract class DataSourceConnectVM<T> : BaseViewModel, IConnectionProvider<T>
        where T : BaseAuthorizationDB
    {
        protected readonly IDialogsConteiner _dialogsConteiner;
        protected readonly IAuthorizationService<T> _authorizationService;

        public DataSourceConnectVM(IAuthorizationService<T> serviceAuthorization, IDialogsConteiner dialogsConteiner)
        {
            _dialogsConteiner = dialogsConteiner;
            _authorizationService = serviceAuthorization;
            DataSourceName = _authorizationService.GetStatusConnect().DataSourceName;
            IsConnect = Convert.ToInt32(_authorizationService.GetStatusConnect().IsConnected);
            _authorizationService.ConnectionEvent += ConnectionOrDisconnection;
            _authorizationService.DisconnectonEvent += ConnectionOrDisconnection;
        }

        protected void ConnectionOrDisconnection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs)
        {
            DataSourceName = eventArgs.DataSourceName;
            IsConnect = Convert.ToInt32(eventArgs.IsConnected);
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

        private RelayCommand? _disconnectCommand;

        public RelayCommand? DisconnectCommand
        {
            get => _disconnectCommand ??= new RelayCommand(async obj =>
            {
                try
                {
                    await _authorizationService.Disconect();
                }
                catch (Exception e)
                {
                    _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                }
            }, _ => IsConnect == 1);
        }

        protected RelayCommand? _connectCommand;

        public abstract RelayCommand? ConnectCommand { get; }
    }
}
