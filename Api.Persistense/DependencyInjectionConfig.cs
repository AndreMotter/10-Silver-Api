using Api.Persistense.Repositories;
using App.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Persistense
{
    public class DependencyInjectionConfig
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
