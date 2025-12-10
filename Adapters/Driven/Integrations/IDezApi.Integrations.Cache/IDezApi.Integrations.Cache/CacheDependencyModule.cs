using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IDezApi.Integrations.Cache
{
    public static class CacheDependencyModule
    {
        public static IServiceCollection AddCacheDependencyModule(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddSingleton<ICacheService, CacheService>();
            return services;
        }

    }
}
