using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using DSTest.Infrastructure.Dal.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DSTest.Infrastructure.Dal.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    private readonly IServiceProvider _scopeFactory;

    public BaseRepository(IServiceProvider scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task Save(T entity)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();

        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            await context.Set<T>().AddAsync(entity);
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }

        await context.SaveChangesAsync();
    }

    public async Task SaveAll(IEnumerable<T> entities)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();

        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            foreach (var entity in entities)
            {
                await context.Set<T>().AddAsync(entity);
            }

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> Query(int take, int offset)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();
        return await context.Set<T>()
            .Skip(offset)
            .Take(take)
            .ToListAsync();
    }

    public async Task<int> GetCount()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();
        return await context.Set<T>()
            .CountAsync();
    }
}