using IDezApi.Application.UseCases.Municipios;
using IDezApi.Domain.Application.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IDezApi.Application;

public static class ApplicationDependencyModule
{
    public static IServiceCollection AddApplicationDependencyModule(this IServiceCollection services, IConfiguration configuration)
    {
        // registrar
        services.AddScoped<IBuscarMunicipiosUseCase, BuscarMunicipiosUseCase>();
        services.AddScoped<IPesquisarMunicipiosUseCase, PesquisarMunicipiosUseCase>();


        return services;
    }
}
