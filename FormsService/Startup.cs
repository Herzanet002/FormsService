using System.Reflection;
using System.Text.Json.Serialization;
using Application;
using FormsService.API.Middleware;
using FormsService.API.Services;
using FormsService.API.Services.Interfaces;
using Infrastructure;
using MailService.Extensions;
using Microsoft.AspNetCore.Mvc;

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

        services.AddDbContext(Configuration);
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

        //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).ConfigureApiBehaviorOptions(options =>
        //{
        //    //options.InvalidModelStateResponseFactory = c =>
        //    //{
        //    //    ProblemDetails problemDetails = new ProblemDetails();
        //    //    problemDetails.Status = StatusCodes.Status400BadRequest;
        //    //    problemDetails.Title = "One or more validation errors occurred.";
        //    //    problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";

        //    //    List<object> codeMessages = new List<object>();
        //    //    foreach (var modelState in c.ModelState)
        //    //    {
        //    //        if (modelState.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
        //    //        {
        //    //            string[] errorMessageCode = modelState.Value.Errors.Select(a => a.ErrorMessage).FirstOrDefault().Split(':');
        //    //            string code = errorMessageCode[0];
        //    //            string message = errorMessageCode.Length > 1 ? errorMessageCode[1]: string.Empty;

        //    //            codeMessages.Add(new {field= modelState.Key, code= code, message= message});
        //    //        }
        //    //    }

        //    //    problemDetails.Extensions.Add("Invalid Fields", codeMessages);

        //    //    return new BadRequestObjectResult(problemDetails);
        //    //};
        //});
        services.AddScoped(typeof(IWordWorkerService<>), typeof(WordWorkerServiceService<>));
        services.AddScoped(typeof(ExcelWorkerService<>));
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