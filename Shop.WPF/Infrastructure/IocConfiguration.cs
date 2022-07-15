using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.DataTransferObject;
using System;
using Shop.WPF.Interfaces;
using Shop.WPF.Dialogs;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;

using Shop.WPF.ViewModel;

namespace Shop.WPF.Infrastructure
{
    internal class IocConfiguration
    {
        public IServiceProvider CreateHostBuilder()
        {
            ServiceCollection services = new ServiceCollection();

            #region Dialogs

            services.AddSingleton<IErrorDialog, ErrorDialog>();
            services.AddSingleton<IAuthorizationOleDBDialog ,AuthorizationOleDBDialog>();
            services.AddSingleton<IAuthorizationMSSQLDialog, AuthorizationMSSQLDialog>();

            #endregion

            #region ServicesBusinessLayer

            services.AddScoped<IAuthorizationService<AuthorizationOleDBDataDTO>, AuthorizationOleDBService>();
            services.AddScoped<IAuthorizationService<AuthorizationMSSQLDataDTO>, AuthorizationMSSQLService>();

            #endregion

            #region ServicesVM

            services.AddSingleton<IConnectionProvider<AuthorizationOleDBDataDTO>, DataSourceConnectOleDBVM>();
            services.AddSingleton<IConnectionProvider<AuthorizationMSSQLDataDTO>, DataSourceConnectMSSQLVM>();
            #endregion

            return services.BuildServiceProvider();
        }
    }
}
