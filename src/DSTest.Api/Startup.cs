using System.Reflection;
using DSTest.Api.Middlewares;
using DSTest.Application.Extensions;
using DSTest.Application.Template.Queries;
using DSTest.Infrastructure;

namespace DSTest.Api;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly string _corsPolicyName = "frontend";

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddInfrastructure(_configuration);
        services.AddApplication();

        services.AddMediatR(configuration =>
        {
            configuration.Lifetime = ServiceLifetime.Scoped;
            configuration.RegisterServicesFromAssembly(typeof(GetTemplateQuery).GetTypeInfo().Assembly);
        });
        
        services.AddCors(o => o.AddPolicy(_corsPolicyName, builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
    }

    public void Configure(IHostEnvironment environment, IApplicationBuilder app)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.Use(async (context, next) =>
        {
            context.Request.EnableBuffering();
            await next.Invoke();
        });

        app.UseMiddleware<ErrorMiddleware>();
        app.UseCors(_corsPolicyName);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}