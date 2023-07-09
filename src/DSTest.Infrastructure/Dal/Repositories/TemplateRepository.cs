using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using DSTest.Domain.Options;
using DSTest.Infrastructure.Dal.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSTest.Infrastructure.Dal.Repositories;

public class TemplateRepository : ITemplateRepository
{
    private readonly IOptionsMonitor<ServiceOptions> _options;
    private readonly IServiceProvider _scopeFactory;

    public TemplateRepository(IOptionsMonitor<ServiceOptions> options, IServiceProvider scopeFactory)
    {
        _options = options;
        _scopeFactory = scopeFactory;
    }

    public async Task Save(WeatherEntity entity)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();

        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            await context.Templates.AddAsync(entity);
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<WeatherEntity>> Query()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();
        return await context.Templates.ToListAsync();
    }
}