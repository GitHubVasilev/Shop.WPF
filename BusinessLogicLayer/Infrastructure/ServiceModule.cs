using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Infrastructure
{
    public class ServiceModule
    {
        public ServiceCollection CreateHostBuilder() 
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }
            
    }
}
