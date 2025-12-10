using IDezApi.Api.Mapping;
using IDezApi.Api.Validation;
using IDezApi.Application;
using IDezApi.Integrations.Cache;
using IDezApi.Integrations.GenericClient;
using IDezApi.Integrations.MunicipioService;
namespace IDezApi.Api
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar CORS antes do Build
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevCorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();

                });
            });

            // HttpClient 
            builder.Services.AddGenericClientHttpDependencyModule(builder.Configuration);


            //Controller e Endpoints
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Injeção dos módulos customizados  

            builder.Services.AddBusinessValidationsDependencyModule();

            builder.Services.AddCacheDependencyModule(builder.Configuration);

            // Serviços de Integração customizados
            builder.Services.AddMunicipioDependencyModule(builder.Configuration);

            // Application
            builder.Services.AddApplicationDependencyModule(builder.Configuration);

            // AutoMapper
            builder.Services.AddMappingDependencyModule();

            var app = builder.Build();

            app.UseCors("DevCorsPolicy");

            /// Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
