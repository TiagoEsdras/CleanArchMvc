using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchMvc.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureAPI(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchMvc.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, ISeedUserRoleInitial seedUserRoleInitial)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchMvc.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}