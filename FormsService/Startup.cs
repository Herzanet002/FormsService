using Microsoft.OpenApi.Models;
using System.Reflection;
using MailService;
using MailService.Configurations;
using MailService.Extensions;
using Microsoft.Extensions.Configuration;

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
            services.AddMvc();


            //services.Configure<MailServiceClient>(Configuration);

            services.AddMailHostedService().
                ConfigureMailService(Configuration);

            services
                .AddEmailService()
                .ConfigureEmailService(Configuration);

            //services.AddSingleton<IMailServiceClient, MailServiceClient>();
            //services.AddSingleton<MailHostedService>();
            //services.AddScoped<IMailServiceClient, MailServiceClient>();
            //services.AddHostedService<MailHostedService>();
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
