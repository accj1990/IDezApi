using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp;

namespace IDezApi.Integrations.GenericClient
{
    public static class GenericClientHttpDependencyModule
    {
        public static IServiceCollection AddGenericClientHttpDependencyModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("DefaultClient", client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddSingleton<IGenericClientHttp, GenericClientHttp>();

            return services;
        }

    }
}
