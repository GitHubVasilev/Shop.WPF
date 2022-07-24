using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shop.WPF.Interfaces;
using Shop.WPF.ViewModel;
using Shop.WPF.ViewModel.Customers;
using Shop.WPF.ViewModel.Orders;
using System;

namespace Shop.WPF.Infrastructure
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _locator;

        public ViewModelLocator()
        {
            IocConfiguration locator = new IocConfiguration();
            _locator = locator.CreateHostBuilder(new ServiceModule().CreateHostBuilder());
        }

        public DataSourceConnectOleDBVM DataSourceOleDBVM =>
            (_locator.GetRequiredService<IConnectionProvider<AuthorizationOleDBDataDTO>>() as DataSourceConnectOleDBVM)!;

        public DataSourceConnectMSSQLVM DataSourceMSSQLVM =>
            (_locator.GetRequiredService<IConnectionProvider<AuthorizationMSSQLDataDTO>>() as DataSourceConnectMSSQLVM)!;

        public AuthorizationOleDBDataVM AuthorizationOleDBDataVM =>
            _locator.GetRequiredService<AuthorizationOleDBDataVM>();

        public AuthorizationMSSQLDataVM AuthorizationMSSQLDataVM =>
            _locator.GetRequiredService<AuthorizationMSSQLDataVM>();

        public AddCustomerVM AddCustomersVM =>
            _locator.GetRequiredService<AddCustomerVM>();

        public CustomersVM CustomersVM =>
            _locator.GetRequiredService<CustomersVM>();

        public AddOrderVM AddOrderVM 
        {
            get 
            {
                AddOrderVM vm = _locator.GetRequiredService<AddOrderVM>();
                vm.Order.Email = CustomersVM.SelectedCustomer?.Email;
                return vm;
            }
        }

        public OrdersVM Orders 
        {
            get 
            {
                OrdersVM vm = _locator.GetRequiredService<OrdersVM>();
                vm.SelectedCustomer = CustomersVM.SelectedCustomer;
                return vm;
            }
        }
            
        public UpdateCustomerVM UpdateCustomerVM 
        {
            get 
            {
                UpdateCustomerVM vm = _locator.GetRequiredService<UpdateCustomerVM>();
                vm.Customer = CustomersVM.SelectedCustomer ?? new CustomerVM();
                return vm;
            }
        }
    }
}
