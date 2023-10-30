using Api.Application.Services;
using App.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Application
{
    public class DependencyInjectionConfig
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
        }
    }
}
