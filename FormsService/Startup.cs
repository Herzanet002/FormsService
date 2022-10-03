using MailService.Extensions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FormsService.DAL.Context;
using FormsService.DAL.Repository;
using FormsService.DAL.Repository.Interfaces;
using MailService.Models;

namespace FormsService
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DatabaseContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("DbSource")));

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

            services.AddMailHostedService()
                .ConfigureIMapService(Configuration)
                .AddIMapClientService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"My API v{Assembly.GetExecutingAssembly().GetName().Version}");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}