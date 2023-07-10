using DSTest.Infrastructure.Dal.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DSTest.Application.Extensions;

public static class AddMigrationManager
{
    public static IServiceCollection ApplyPendingMigrations(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();
        var context = sp.GetRequiredService<DsTestContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        return services;
    }
}