using IDezApi.Domain.Adapters.Driven.Integrations.Services;
using IDezApi.Integrations.MunicipioService.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IDezApi.Integrations.MunicipioService
{
    public static class MunicipioServiceDependencyModule
    {
        public static IServiceCollection AddMunicipioDependencyModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBuscarMunicipioService, BuscarMunicipiosService>();
            services.AddSingleton<IPesquisarMunicipioService, PesquisarMunicipioService>();

            return services;
        }
    }
}
