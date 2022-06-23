using Microsoft.Extensions.DependencyInjection;
using Training.Kanban.API.Interfaces;
using Training.Kanban.API.Services;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Infraestructure.Repositories;

namespace Training.Kanban.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            return services;
        }
    }
}
