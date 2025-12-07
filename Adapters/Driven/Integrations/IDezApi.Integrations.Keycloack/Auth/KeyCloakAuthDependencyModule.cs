using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using IDezApi.Domain.Adapters.Driven.Integrations.Keycloak;
using IDezApi.KeyCloak.Service;

namespace IDezApi.Integrations.Keycloak.Auth
{
    public static class KeyCloakAuthDependencyModule
    {
        public static IServiceCollection AddKeyCloakAuthDependencyModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var authority = configuration["KeyCloak:Authority"];
            var audience = configuration["KeyCloak:Audience"];

            services
                .AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = authority;
                    options.RequireHttpsMetadata = false;

                    // Keycloak precisa disso
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authority,

                        ValidateAudience = true,
                        ValidAudience = audience,

                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true
                    };
                });

            services.AddAuthorization();

            services.AddTransient<IKeycloakService, KeycloakService>();

            return services;
        }
    }
}
