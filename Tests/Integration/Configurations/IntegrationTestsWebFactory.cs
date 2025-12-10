using MassTransit;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace IDezApi.Tests.Integration.Configurations
{
    public class IntegrationTestsWebFactory<TProgram> : WebApplicationFactory<TProgram>
         where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureAppConfiguration((context, config) =>
            {
                // Limpa qualquer configuração existente
                config.Sources.Clear();

                // Adiciona arquivos de configuração
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json");
                config.AddJsonFile($"appsettings.Testing.json", optional: true);
                config.AddEnvironmentVariables();
            });
            builder.ConfigureServices(services =>
            {
                // Adiciona Seeders e serviços necessários
                //services.AddScoped<UserSeeders>();

                // Configura o MassTransit para testes
                services.AddMassTransitTestHarness();


                // Configura o contexto do banco de dados para testes
                //ConfigureDatabase(services);
            });
        }

    }
}
