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
            _isConnect = _connectionService.GetStatusConnect().IsConnected ?? false;
        }

        private bool _isConnect;

        private CustomerVM? _selectedCustomer;

        public CustomerVM? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                Update();
            }
        }

        public ObservableCollection<OrderVM> Orders { get; }

        private void ConnectionOrDisconection(IAuthorizationService<AuthorizationOleDBDataDTO> sender, DataConnectionDBDTO eventArgs)
        {
            _isConnect = _isConnect == true ? false : true;
            Update();
        }

        private RelayCommand? _clear;
        public RelayCommand ClearCommand
        {
            get => _clear ??= new RelayCommand(obj =>
            {
                IWarningDialog dialog = _dialogsConteiner.WarningDialog;
                dialog.ShowDialog("Do you need to delete all customers?");
                if (dialog.ResultDialog() ?? false)
                {
                    try
                    {
                        _service.Crear();
                        Update();
                    }
                    catch (Exception e)
                    {
                        _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                    }
                }
            }, _ => _isConnect);
        }

        private RelayCommand? _addOrder;
        public RelayCommand AddOrderCommand
        {
            get => _addOrder ??= new RelayCommand(obj =>
            {
                try
                {
                    _dialogsConteiner.AddOrderDialog.ShowDialog();
                    Update();
                }
                catch (Exception e)
                {
                    _dialogsConteiner.ErrorDialog?.ShowDialog(e.Message);
                }
            }, _ => _isConnect);
        }

        private void Update()
        {
            if (_isConnect)
            {
                Orders.Clear();
                if (SelectedCustomer is null) return;
                foreach (OrderDTO order in _service.Get(SelectedCustomer!.Email!))
                {
                    Orders.Add(new OrderVM(order));
                }
            }
        }
    }
}
