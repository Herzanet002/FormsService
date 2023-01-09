using Application;
using Infrastructure;
using Infrastructure.Services;
using MailService.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FormsService.API;

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

		services.AddPostresqlDatabase(Configuration);
		services.AddCommandHandlers();
		services.AddControllers()
			.AddJsonOptions(o =>
			{
				o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
			});
		services.AddEndpointsApiExplorer();

		services.AddSwaggerGen();
		services.AddMailHostedService()
			.ConfigureIMapService(Configuration)
			.ConfigureFormsService(Configuration)
			.AddIMapClientService();

		services.AddReportsServices();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json",
					$"My API v{Assembly.GetExecutingAssembly().GetName().Version}");
			});
		}

		//app.UseMiddleware<LoggerMiddleware>();
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
			endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
		});
	}
}