using AutoMapper;

using IDezApi.Domain.Adapters.Driving.Api.Mapping;

namespace IDezApi.Api.Mapping
{
    public static class MappingDependencyModule
    {

        public static IServiceCollection AddMappingDependencyModule(this IServiceCollection services)
        {
            // AutoMapper     
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IMapperService, MapperService>();
            return services;
        }
    }
}
