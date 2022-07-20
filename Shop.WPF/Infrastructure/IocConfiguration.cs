using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.DataTransferObject;
using System;
using Shop.WPF.Interfaces;
using Shop.WPF.Dialogs;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.ViewModel;
using BusinessLogicLayer.DataTransferObject.Entitys;

namespace Shop.WPF.Infrastructure
{
    internal class IocConfiguration
    {
        public IServiceProvider CreateHostBuilder(IServiceCollection services) 
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
            services.AddScoped<AuthorizationMSSQLDataVM>();
            services.AddScoped<AuthorizationOleDBDataVM>();

            #endregion

            return services.BuildServiceProvider();
        }
    }
}
