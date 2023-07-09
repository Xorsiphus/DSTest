using System.Reflection;
using DSTest.Application.Behaviours;
using DSTest.Application.Template.Queries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DSTest.Application.Extensions;

public static class AddApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<ITemplateService, TemplateService>();
        
        services.AddValidatorsFromAssembly(typeof(GetTemplateQuery).GetTypeInfo().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }

}