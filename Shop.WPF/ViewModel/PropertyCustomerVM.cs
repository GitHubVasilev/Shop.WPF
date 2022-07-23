using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Orders;
using System;
using System.Collections.ObjectModel;

namespace Shop.WPF.ViewModel
{
    internal class PropertyCustomerVM
    {
        private readonly IService<OrderDTO> _service;
        private readonly IDialogsConteiner _dialogsConteiner;
        private readonly IAuthorizationService<AuthorizationOleDBDataDTO> _connectionService;

        public PropertyCustomerVM(IService<OrderDTO> service,
                                  IDialogsConteiner dialogConteiner,
                                  IAuthorizationService<AuthorizationOleDBDataDTO> connectionService)
        {
            _dialogsConteiner = dialogConteiner;
            _service = service;
            Orders = new ObservableCollection<OrderVM>();
            _connectionService = connectionService;

            _connectionService.ConnectionEvent += ConnectionOrDisconection;
            _connectionService.DisconnectonEvent += ConnectionOrDisconection;
            Update();
        }

        private bool _isConnect;

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
                _dialogsConteiner.AddOrderDialog.ShowDialog();
            }, _ => _isConnect);
        }

        private void Update()
        {
            if (_isConnect)
            {
                Orders.Clear();
                foreach (OrderDTO order in _service.Get())
                {
                    Orders.Add(new OrderVM(order));
                }
            }
        }
    }
}
