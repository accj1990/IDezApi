using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Api.Validation.User;

namespace IDezApi.Api.Validation
{
    public static class BusinessValidationsDependencyModule
    {
        public static IServiceCollection AddBusinessValidationsDependencyModule(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();

            services.AddScoped<IValidator<GetAllUserRequest>, GetAllUserRequestValidator>();

            services.AddScoped<IValidator<GetUserRequest>, GetUserRequestValidator>();

            services.AddScoped<IValidator<DeleteUserRequest>, DeleteUserRequestValidator>();

            services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();

            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidation>();

            services.AddScoped<IValidator<TokenRequest>, TokenRequestValidation>();

            services.AddScoped<IValidator<LogoutRequest>, LogoutRequestValidation>();

            return services;
        }
    }
}
