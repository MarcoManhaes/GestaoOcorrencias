using Microsoft.Extensions.DependencyInjection;
using GestaoOcorrencias.Data;
using GestaoOcorrencias.Data.Interfaces;
using GestaoOcorrencias.Data.Repositories;
using GestaoOcorrencias.Service.Interfaces;
using GestaoOcorrencias.Service.Services;
using Microsoft.Extensions.Caching.Memory;

namespace GestaoOcorrencias.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationContext>();

            /*services*/
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOcorrenciaService, OcorrenciaService>();

            /*repositories*/
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
            

            return services;
        }
    }
}