using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IDezApi.Application;

public static class ApplicationDependencyModule
{
    public static IServiceCollection AddApplicationDependencyModule(this IServiceCollection services, IConfiguration configuration)
    {
        // registrar
        //services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();


        return services;
    }
}
