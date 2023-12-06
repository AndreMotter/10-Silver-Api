﻿using Api.Application.Services;
using App.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Application
{
    public class DependencyInjectionConfig
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IFin_PessoaService, Fin_PessoaService>();
            services.AddTransient<IFin_MovimentacaoService, Fin_MovimentacaoService>();
            services.AddTransient<IFin_categoriaService, Fin_categoriaService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}
