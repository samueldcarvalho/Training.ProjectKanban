using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Training.Kanban.API.Configurations;
using Training.Kanban.API.Interfaces;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Infraestructure.Contexts;
using Training.Kanban.Infraestructure.Repositories;

namespace Training.Kanban.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {  
            services.AddServicesConfiguration();
            services.AddJwtConfiguration();
            services.AddSwaggerConfiguration();

            var connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContextPool<KanbanDbContext>(options =>
            {
                options.UseMySql(
                    connectionString, 
                    ServerVersion.AutoDetect(connectionString), 
                    a => a.MigrationsAssembly("Training.Kanban.API"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Training.Kanban.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
