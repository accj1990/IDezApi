using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IDezApi.Storage.PostgreSQL.EF
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..")), "Driving", "Api");

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath) // Caminho onde está o appsettings.json
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("DB_POSTGRESQL"));



            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
