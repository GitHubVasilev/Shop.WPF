using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Shop.WPF.ViewModel.Customers
{
    internal class CustomersVM : BaseViewModel
    {
        private readonly IService<CustomerDTO> _service;
        private readonly IAuthorizationService<AuthorizationOleDBDataDTO> _connectionService;
        private readonly IDialogsConteiner _dialogs;

        public CustomersVM(
            IService<CustomerDTO> service,
            IAuthorizationService<AuthorizationOleDBDataDTO> authorizationService,
            IDialogsConteiner dialogsConteiner)
        {
            _dialogs = dialogsConteiner;
            _service = service;
            _connectionService = authorizationService;
            Customers = new();

            _service.NotifyUpdateData += Update;
            _connectionService.DisconnectonEvent += ConnectionOrDisconection;
            _connectionService.ConnectionEvent += ConnectionOrDisconection;
        }

        private bool _isConnect;

        private ObservableCollection<CustomerVM>? _customers;
        public ObservableCollection<CustomerVM> Customers
        {
            get => _customers ?? new ObservableCollection<CustomerVM>();
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private CustomerVM? _selectedCustomer;

        public CustomerVM? SelectedCustomer 
        {
            get => _selectedCustomer;
            set 
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _addCustomer;

        public RelayCommand AddCustomerCommand
        {
            get => _addCustomer ??= new RelayCommand(obj =>
            {
                IAddCustomerDialog dialog = _dialogs.AddCustomerDialog;
                dialog.ShowDialog();
            }, _ => _isConnect);
        }

        private RelayCommand? _propertyCustomer;

        public RelayCommand PropertyCustomerCommand
        {
            get => _propertyCustomer ??= new RelayCommand(obj =>
            {
                _dialogs.PropertyCustomerDialog.ShowDialog();
            }, _ => _isConnect);
        }

        private RelayCommand? _clearTables;

        public RelayCommand ClearTablesCommand
        {
            get => _clearTables ??= new RelayCommand(obj =>
            {
                IWarningDialog dialog = _dialogs.WarningDialog;
                dialog.ShowDialog("Do you need to delete all customers?");
                if (dialog.ResultDialog() ?? false) 
                {
                    try
                    {
                        _service.Crear();
                    }
                    catch (Exception e) 
                    {
                        _dialogs.ErrorDialog.ShowDialog(e.Message);
                    }
                }
            }, _ => _isConnect);
        }

        private void ConnectionOrDisconection(IAuthorizationService<AuthorizationOleDBDataDTO> sender, DataConnectionDBDTO eventArgs)
        {
            _isConnect = _connectionService.GetStatusConnect().IsConnected ?? false;
            Update(_service, null);
        }

        private async void Update(IService<CustomerDTO> sender, object? eventArgs)
        {
            Debug.WriteLine("Update");
            if (_isConnect)
            {
                try
                {
                    Customers = new ObservableCollection<CustomerVM>();
                    foreach (CustomerDTO customer in await _service.Get())
                    {
                        Customers.Add(new CustomerVM(customer));
                    }
                }
                catch (Exception e) 
                {
                    _dialogs?.ErrorDialog.ShowDialog(e.Message);
                }
                
            }
        }
    }
}
