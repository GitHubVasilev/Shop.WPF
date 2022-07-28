using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces;
using Shop.WPF.Interfaces.Dialogs;
using System;

namespace Shop.WPF.ViewModel.Base
{
    /// <summary>
    /// Базовый класс модели предстваления для соединения с источником данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
            IsConnect = Convert.ToInt32(_authorizationService.GetStatusConnect().IsConnect);
            _authorizationService.ConnectionEvent += ConnectionOrDisconnection;
            _authorizationService.DisconnectonEvent += ConnectionOrDisconnection;
        }

        protected void ConnectionOrDisconnection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs)
        {
            DataSourceName = eventArgs.DataSourceName;
            IsConnect = Convert.ToInt32(eventArgs.IsConnect);
        }

        private string? _dataSourceName;
        /// <summary>
        /// Строка подключения
        /// </summary>
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
        /// <summary>
        /// Флаг соединения с источником данных
        /// True - подключен
        /// False - отключен
        /// </summary>
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

        /// <summary>
        /// Команда для разрыва соединения с источником данных
        /// </summary>
        public RelayCommand? DisconnectCommand
        {
            get => _disconnectCommand ??= new RelayCommand(async obj =>
            {
                try
                {
                    await _authorizationService.DisconectAsync();
                }
                catch (Exception e)
                {
                    _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                }
            }, _ => IsConnect == 1);
        }

        protected RelayCommand? _connectCommand;

        /// <summary>
        /// Команда для создания соединения с источником данных
        /// </summary>
        public abstract RelayCommand? ConnectCommand { get; }
    }
}
