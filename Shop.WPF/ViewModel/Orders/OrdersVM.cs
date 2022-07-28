using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using Shop.WPF.ViewModel.Customers;
using System;
using System.Collections.ObjectModel;

namespace Shop.WPF.ViewModel.Orders
{
    /// <summary>
    /// Модель предстваления обработки заказов
    /// </summary>
    internal class OrdersVM : BaseViewModel
    {
        private readonly IService<OrderDTO> _service;
        private readonly IDialogsConteiner _dialogsConteiner;
        private readonly IAuthorizationService<AuthorizationOleDBDataDTO> _connectionService;

        public OrdersVM(IService<OrderDTO> service,
                        IDialogsConteiner dialogConteiner,
                        IAuthorizationService<AuthorizationOleDBDataDTO> connectionService)
        {
            _dialogsConteiner = dialogConteiner;
            _service = service;
            Orders = new ObservableCollection<OrderVM>();
            _connectionService = connectionService;

            _connectionService.ConnectionEvent += ConnectionOrDisconection;
            _connectionService.DisconnectonEvent += ConnectionOrDisconection;
            _service.NotifyUpdateData += Update;

            _isConnect = _connectionService.GetStatusConnect().IsConnect ?? false;
        }

        private bool _isConnect;

        private CustomerVM? _selectedCustomer;

        /// <summary>
        /// Покупатель - владелец заказов
        /// </summary>
        public CustomerVM? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = new CustomerVM(value?.BaseModel);
                Update(_service, null);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список заказов
        /// </summary>
        public ObservableCollection<OrderVM> Orders { get; }

        private void ConnectionOrDisconection(IAuthorizationService<AuthorizationOleDBDataDTO> sender, DataConnectionDBDTO eventArgs)
        {
            _isConnect = _connectionService.GetStatusConnect().IsConnect ?? false;
        }

        private RelayCommand? _clear;
        /// <summary>
        /// Команда для очистки списка заказов в источнике данных
        /// </summary>
        public RelayCommand ClearCommand
        {
            get => _clear ??= new RelayCommand(async obj =>
            {
                IWarningDialog dialog = _dialogsConteiner.WarningDialog;
                dialog.ShowDialog("Do you need to delete all customers?");
                if (dialog.ResultDialog() ?? false)
                {
                    try
                    {
                         await _service.CrearAsync();
                    }
                    catch (Exception e)
                    {
                        _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                    }
                }
            }, _ => _isConnect);
        }

        private RelayCommand? _addOrder;
        /// <summary>
        /// Команда добавления нового заказа
        /// </summary>
        public RelayCommand AddOrderCommand
        {
            get => _addOrder ??= new RelayCommand(obj =>
            {
                try
                {
                    _dialogsConteiner.AddOrderDialog.ShowDialog();
                }
                catch (Exception e)
                {
                    _dialogsConteiner.ErrorDialog?.ShowDialog(e.Message);
                }
            }, _ => _isConnect);
        }

        private async void Update(IService<OrderDTO> sender, object? eventArgs)
        {
            if (SelectedCustomer is null) return;
            if (_isConnect)
            {
                try
                {
                    Orders.Clear();
                    foreach (OrderDTO order in await _service.GetAsync(SelectedCustomer!.Email!))
                    {
                        Orders.Add(new OrderVM(order));
                    }
                }
                catch(Exception e) 
                {
                    _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                }
                
            }
        }
    }
}
