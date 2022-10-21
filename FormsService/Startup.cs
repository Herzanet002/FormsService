using System.Reflection;
using System.Text.Json.Serialization;
using FormsService.DAL.Context;
using FormsService.DAL.Repository;
using FormsService.DAL.Repository.Interfaces;
using MailService.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FormsService.API
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
            services.AddControllers().AddJsonOptions(o =>
                o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DatabaseContext>(
                options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DbSource"))
                        .UseSnakeCaseNamingConvention()
                        .EnableSensitiveDataLogging();
                });

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