using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces;
using Shop.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Customers = new List<CustomerVM>();
        }

        private void ConnectionOrDisconection(IAuthorizationService<AuthorizationOleDBDataDTO> sender, DataConnectionDBDTO eventArgs)
        {
            _isConnect = _isConnect == true ? false : true;
        }

        private bool _isConnect;

        private List<CustomerVM> _customers;
        public List<CustomerVM> Customers
        {
            get => _customers;
            set 
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _addCustomer;

        public RelayCommand AddCustomer 
        {
            get => _addCustomer ??= new RelayCommand(obj =>
            {
                
            }, _ => _isConnect);
        }

        private RelayCommand? _propertyCustomer;

        public RelayCommand PropertyCustomer
        {
            get => _propertyCustomer ??= new RelayCommand(obj =>
            {

            }, _ => _isConnect);
        }

        private RelayCommand? _clearTables;

        public RelayCommand ClearTables
        {
            get => _clearTables ??= new RelayCommand(obj =>
            {
                
            }, _ => _isConnect);
        }
    }
}
