using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using IDezApi.Storage.MongoDb.Context;
using IDezApi.Storage.MongoDb.Interfaces;
using IDezApi.Storage.MongoDb.Repositories;

namespace IDezApi.Storage.MongoDb
{
    public static class MongoDBDependencyModule
    {
        public static IServiceCollection AddMongoMongoDBDependencyModule(
            this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DB_MONGODB");
            var databaseLog = configuration.GetConnectionString("DATABASE_LOG")!;

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("A connection string 'DB_MONGODB' não foi encontrada ou está vazia.");

            // adicionar novo contexto caso seja preciso trabalhar com múltiplos bancos MongoDB
            services.AddSingleton(new MongoDbContext(connectionString, databaseLog));
            services.AddScoped(typeof(IMongoDBRepository<>), typeof(MongoDBRepository<>));

            return services;
        }
    }
}
