using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Infrastructure
{
    /// <summary>
    /// Dependency injection conteiner для слоя buisness слоя 
    /// </summary>
    public class ServiceModule
    {
        /// <summary>
        /// Создает коллекцию сервисов
        /// </summary>
        public ServiceCollection CreateHostBuilder() 
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IMapperFactory, MapperFactory>();
            return services;
        }
            
    }
}
