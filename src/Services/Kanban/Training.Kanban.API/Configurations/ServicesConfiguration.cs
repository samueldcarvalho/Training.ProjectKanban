using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Training.Core.CQRS.Services;
using Training.Kanban.API.Services;
using Training.Kanban.Application.Interfaces;
using Training.Kanban.Application.Queries;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Infraestructure.Contexts;
using Training.Kanban.Infraestructure.Repositories;

namespace Training.Kanban.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContextPool<KanbanContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IUserQueries, UserQueries>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMediatR(AppDomain.CurrentDomain.Load("Training.Kanban.Application"));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
