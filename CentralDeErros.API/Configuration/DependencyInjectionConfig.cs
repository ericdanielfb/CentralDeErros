using CentralDeErros.Services;
using CentralDeErros.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CentralDeErros.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {

            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<EnvironmentService>();
            services.AddScoped<LevelService>();
            services.AddScoped<MicrosserviceService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<TokenGeneratorService>();
            services.AddScoped<UserService>();

            return services;

        }
    }
}
