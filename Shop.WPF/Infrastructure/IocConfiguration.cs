using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.DataTransferObject;
using System;
using Shop.WPF.Interfaces;
using Shop.WPF.Dialogs;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.ViewModel;
using BusinessLogicLayer.DataTransferObject.Entitys;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Customers;
using Shop.WPF.ViewModel.Orders;

namespace Shop.WPF.Infrastructure
{
    /// <summary>
    /// Класс для инферсии записимости по созданию экземпляров сервисов
    /// </summary>
    internal class IocConfiguration
    {
        /// <summary>
        /// Создает контейнер с ресурсами приложения
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider CreateHostBuilder(IServiceCollection? services = null) 
        {
            services ??= new ServiceCollection();

            #region Dialogs

            services.AddSingleton<IDialogsConteiner, DialogsConteiner>();

            #endregion

            #region ServicesBusinessLayer

            services.AddScoped<IAuthorizationService<AuthorizationOleDBDataDTO>, AuthorizationOleDBService>();
            services.AddScoped<IAuthorizationService<AuthorizationMSSQLDataDTO>, AuthorizationMSSQLService>();
            services.AddScoped<IService<OrderDTO>, OrderService>();
            services.AddScoped<IService<CustomerDTO>, CustomersService>();

            #endregion

            #region ServicesVM

            services.AddSingleton<IConnectionProvider<AuthorizationOleDBDataDTO>, DataSourceConnectOleDBVM>();
            services.AddSingleton<IConnectionProvider<AuthorizationMSSQLDataDTO>, DataSourceConnectMSSQLVM>();
            services.AddTransient<AddCustomerVM>();
            services.AddScoped<CustomersVM>();
            services.AddTransient<AddOrderVM>();
            services.AddTransient<OrdersVM>();
            services.AddTransient<UpdateCustomerVM>();

            #endregion

            return services.BuildServiceProvider();
        }
    }
}
