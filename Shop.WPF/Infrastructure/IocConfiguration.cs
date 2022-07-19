using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.DataTransferObject;
using System;
using Shop.WPF.Interfaces;
using Shop.WPF.Dialogs;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.ViewModel;
using BusinessLogicLayer.Infrastructure;
using System.Collections.Generic;

namespace Shop.WPF.Infrastructure
{
    internal class IocConfiguration
    {
        public IServiceProvider CreateHostBuilder()
        {
            ServiceCollection services = new ServiceCollection();
            
            ServiceCollection serviceModule = new ServiceModule().CreateHostBuilder();

            foreach (var a in serviceModule) 
            {
                ((ICollection<ServiceDescriptor>)services).Add(a);
            }

            #region Dialogs

            services.AddScoped<IErrorDialog, ErrorDialog>();
            services.AddScoped<IAuthorizationOleDBDialog ,AuthorizationOleDBDialog>();
            services.AddScoped<IAuthorizationMSSQLDialog, AuthorizationMSSQLDialog>();

            #endregion

            #region ServicesBusinessLayer

            services.AddScoped<IAuthorizationService<AuthorizationOleDBDataDTO>, AuthorizationOleDBService>();
            services.AddScoped<IAuthorizationService<AuthorizationMSSQLDataDTO>, AuthorizationMSSQLService>();

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
