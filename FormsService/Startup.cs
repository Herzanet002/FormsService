using FormsService.API.Services;
using FormsService.API.Services.Interfaces;
using FormsService.DAL.Context;
using FormsService.DAL.Repository;
using FormsService.DAL.Repository.Interfaces;
using MailService.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

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
            services.AddCors();
            // services.AddProblemDetails();

            services.AddControllers().AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    //o.JsonSerializerOptions
                    //    .ReferenceHandler = ReferenceHandler.Preserve;
                });
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
                .ConfigureFormsService(Configuration)
                .AddIMapClientService();

            services.AddScoped(typeof(IWordWorkerService<>), typeof(WordWorkerServiceService<>));
            services.AddScoped(typeof(ExcelWorkerService<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<LoggerMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"My API v{Assembly.GetExecutingAssembly().GetName().Version}");
                });
            }
            //app.UseProblemDetails();
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());

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