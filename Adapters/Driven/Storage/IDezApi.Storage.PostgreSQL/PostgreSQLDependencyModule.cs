using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using IDezApi.Domain.Adapters.Driven.Storage;
using IDezApi.Domain.Adapters.Driven.Storage.Repositories;
using IDezApi.Storage.Dapper;
using IDezApi.Storage.PostgreSQL.EF;
using IDezApi.Storage.PostgreSQL.Repositories;
using IDezApi.Storage.PostgreSQL.Repositories.Base;

namespace IDezApi.Storage.PostgreSQL
{
    public static class PostgreSQLDependencyModule
    {
        public static IServiceCollection AddPostgreSQLDependencyModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DB_POSTGRESQL");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("A connection string 'DB_POSTGRESQL' não foi encontrada ou está vazia.");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    // Aqui você pode configurar, por exemplo:
                    npgsqlOptions.MigrationsAssembly("IDezApi.Storage.PostgreSQL");
                });

                options.EnableSensitiveDataLogging(); // Habilite apenas em desenvolvimento
            }, contextLifetime: ServiceLifetime.Scoped);

            services.AddScoped<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString));

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
