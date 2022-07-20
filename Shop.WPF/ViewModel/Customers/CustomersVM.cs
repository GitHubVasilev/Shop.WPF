using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.ViewModel.Base;
using System.Collections.Generic;

namespace Shop.WPF.ViewModel.Customers
{
    internal class CustomersVM : BaseViewModel
    {
        private readonly IService<CustomerDTO> _service;
        private readonly IAuthorizationService<AuthorizationOleDBDataDTO> _connectionService;

        public CustomersVM(
            IService<CustomerDTO> service,
            IAuthorizationService<AuthorizationOleDBDataDTO> authorizationService)
        {
            _service = service;
            _connectionService = authorizationService;
            Customers = new();
            _connectionService.DisconnectonEvent += ConnectionOrDisconection;
            _connectionService.ConnectionEvent += ConnectionOrDisconection;
        }

        private void ConnectionOrDisconection(IAuthorizationService<AuthorizationOleDBDataDTO> sender, DataConnectionDBDTO eventArgs)
        {
            _isConnect = _isConnect == true ? false : true;
        }

        private bool _isConnect;

        private List<CustomerVM>? _customers;
        public List<CustomerVM> Customers
        {
            get => _customers ?? new List<CustomerVM>();
            set 
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _addCustomer;

        public RelayCommand AddCustomerCommand
        {
            get => _addCustomer ??= new RelayCommand(obj =>
            {
                
            }, _ => _isConnect);
        }

        private RelayCommand? _propertyCustomer;

        public RelayCommand PropertyCustomerCommand
        {
            get => _propertyCustomer ??= new RelayCommand(obj =>
            {

            }, _ => _isConnect);
        }

        private RelayCommand? _clearTables;

        public RelayCommand ClearTablesCommand
        {
            get => _clearTables ??= new RelayCommand(obj =>
            {
                
            }, _ => _isConnect);
        }
    }
}
