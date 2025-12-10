using FluentValidation;

using IDezApi.Api.Dtos.Request;

namespace IDezApi.Api.Validation
{
    public static class BusinessValidationsDependencyModule
    {
        public static IServiceCollection AddBusinessValidationsDependencyModule(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BuscarMunicipiosRequest>, BuscarMunicipiosValidation>();

            services.AddScoped<IValidator<PesquisarMunicipiosRequest>, PesquisarMunicipiosValidation>();

            return services;
        }
    }
}
