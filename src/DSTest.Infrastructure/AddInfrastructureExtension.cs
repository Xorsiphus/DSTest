using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using DSTest.Domain.Options;
using DSTest.Infrastructure.Dal.Repositories;
using DSTest.Infrastructure.Dal.Repositories.Contexts;
using DSTest.Infrastructure.Dal.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSTest.Infrastructure;

public static class AddInfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IBaseRepository<WeatherEntity>, WeatherRepository>();
        services.AddSingleton<IWeatherRepository, WeatherRepository>();

        services.Configure<ServiceOptions>(options =>
        {
            options.ConnectionString = configuration["ConnectionString"];
        });

        services.AddDbContext<DsTestContext>(options =>
            options.UseNpgsql(configuration["ConnectionString"]!));

        return services;
    }
}