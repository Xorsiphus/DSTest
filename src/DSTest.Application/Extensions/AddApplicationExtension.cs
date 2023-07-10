using System.Reflection;
using DSTest.Application.Behaviours;
using DSTest.Application.CQRS.Queries;
using DSTest.Application.Services;
using DSTest.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DSTest.Application.Extensions;

public static class AddApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWeatherService, WeatherService>();
        
        services.AddValidatorsFromAssembly(typeof(GetWeatherDataQuery).GetTypeInfo().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}