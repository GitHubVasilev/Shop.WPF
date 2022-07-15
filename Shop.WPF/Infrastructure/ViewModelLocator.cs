using BusinessLogicLayer.DataTransferObject;
using Microsoft.Extensions.DependencyInjection;
using Shop.WPF.Interfaces;
using Shop.WPF.ViewModel;
using System;

namespace Shop.WPF.Infrastructure
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _locator;

        public ViewModelLocator()
        {
            IocConfiguration locator = new IocConfiguration();
            _locator = locator.CreateHostBuilder();
        }

        public DataSourceConnectOleDBVM DataSourceOleDBVM =>
            (_locator.GetRequiredService<IConnectionProvider<AuthorizationOleDBDataDTO>>() as DataSourceConnectOleDBVM)!;

        public DataSourceConnectMSSQLVM DataSourceMSSQLVM =>
            (_locator.GetRequiredService<IConnectionProvider<AuthorizationMSSQLDataDTO>>() as DataSourceConnectMSSQLVM)!;

        public AuthorizationOleDBDataVM AuthorizationOleDBDataVM =>
            _locator.GetRequiredService<AuthorizationOleDBDataVM>();

        public AuthorizationMSSQLDataVM AuthorizationMSSQLDataVM =>
            _locator.GetRequiredService<AuthorizationMSSQLDataVM>();
    }
}
