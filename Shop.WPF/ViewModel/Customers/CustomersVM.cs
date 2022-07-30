using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shop.WPF.ViewModel.Customers
{
    /// <summary>
    /// Модель предстваления для управления пользователями
    /// </summary>
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
        /// <summary>
        /// Список пользователей
        /// </summary>
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
        /// <summary>
        /// Выбранный пользователь
        /// </summary>
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
        /// <summary>
        /// Команда вызывающее диалоговое окно добавления нового покупателя
        /// </summary>
        public RelayCommand AddCustomerCommand
        {
            get => _addCustomer ??= new RelayCommand(obj =>
            {
                IAddCustomerDialog dialog = _dialogs.AddCustomerDialog;
                dialog.ShowDialog();
            }, _ => _isConnect);
        }

        private RelayCommand? _propertyCustomer;
        /// <summary>
        /// Команда вызывающее диалоговое окно свойство выбранного покупателя
        /// </summary>
        public RelayCommand PropertyCustomerCommand
        {
            get => _propertyCustomer ??= new RelayCommand(obj =>
            {
                _dialogs.PropertyCustomerDialog.ShowDialog();
            }, _ => _isConnect);
        }

        private RelayCommand? _clearTables;
        /// <summary>
        /// Команда для очистки таблицы с данными
        /// </summary>
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
                        _service.CrearAsync();
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
            _isConnect = _connectionService.GetStatusConnect().IsConnect ?? false;
            Update(_service, null);
        }

        private async void Update(IService<CustomerDTO> sender, object? eventArgs)
        {
            string selectedCustomer = "";
            if (SelectedCustomer is not null) 
            {
                selectedCustomer = SelectedCustomer.Email ?? "";
            }
            if (_isConnect)
            {
                try
                {
                    Customers = new ObservableCollection<CustomerVM>();
                    foreach (CustomerDTO customer in await _service.GetAsync())
                    {
                        Customers.Add(new CustomerVM(customer));
                    }
                    IEnumerable<CustomerVM> findCustomers = Customers.Where(m => m.Email == selectedCustomer);
                    if (findCustomers.Count() > 0) 
                    {
                        SelectedCustomer = findCustomers.First();
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
