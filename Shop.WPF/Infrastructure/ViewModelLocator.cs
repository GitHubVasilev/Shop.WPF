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
    /// <summary>
    /// Собирательный класс для моделей предлстваления
    /// </summary>
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _locator;

        public ViewModelLocator()
        {
            IocConfiguration locator = new();
            _locator = locator.CreateHostBuilder(new ServiceModule().CreateHostBuilder());
        }

        /// <summary>
        /// Модель представления статуса подключения к MS Access 
        /// </summary>
        public DataSourceConnectOleDBVM DataSourceOleDBVM =>
            (_locator.GetRequiredService<IConnectionProvider<AuthorizationOleDBDataDTO>>() as DataSourceConnectOleDBVM)!;

        /// <summary>
        /// Модель представления статуса подключения к MS SQL
        /// </summary>
        public DataSourceConnectMSSQLVM DataSourceMSSQLVM =>
            (_locator.GetRequiredService<IConnectionProvider<AuthorizationMSSQLDataDTO>>() as DataSourceConnectMSSQLVM)!;

        /// <summary>
        /// Модель представления статуса подключения к MS Access
        /// </summary>
        public AuthorizationOleDBDataVM AuthorizationOleDBDataVM =>
            _locator.GetRequiredService<AuthorizationOleDBDataVM>();

        /// <summary>
        /// Модель представления статуса подключения к MS MSQ
        /// </summary>
        public AuthorizationMSSQLDataVM AuthorizationMSSQLDataVM =>
            _locator.GetRequiredService<AuthorizationMSSQLDataVM>();

        /// <summary>
        /// Модель представления для добавления покупателя
        /// </summary>
        public AddCustomerVM AddCustomersVM =>
            _locator.GetRequiredService<AddCustomerVM>();

        /// <summary>
        /// Модель представления для работы с покупателями
        /// </summary>
        public CustomersVM CustomersVM =>
            _locator.GetRequiredService<CustomersVM>();

        /// <summary>
        /// Модель представления для создания нового заказа
        /// </summary>
        public AddOrderVM AddOrderVM 
        {
            get 
            {
                AddOrderVM vm = _locator.GetRequiredService<AddOrderVM>();
                vm.Order.Email = CustomersVM.SelectedCustomer?.Email;
                return vm;
            }
        }

        /// <summary>
        /// Модель представления для работы с заказми
        /// </summary>
        public OrdersVM Orders 
        {
            get 
            {
                OrdersVM vm = _locator.GetRequiredService<OrdersVM>();
                vm.SelectedCustomer = CustomersVM.SelectedCustomer;
                return vm;
            }
        }

        /// <summary>
        /// Модель представления для обновления данных покупателя
        /// </summary>
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
