using DSTest.Domain.Entities;
using DSTest.Infrastructure.Dal.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DSTest.Infrastructure.Dal.Repositories.Impl;

public class WeatherRepository : BaseRepository<WeatherEntity>, IWeatherRepository
{
    public WeatherRepository(IServiceProvider scopeFactory) : base(scopeFactory)
    {
    }

    public async Task<IEnumerable<int>> GetYearsInterval()
    {
        using var scope = ScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DsTestContext>();
        
        DateTime minYear = default;
        DateTime maxYear = default;
        if (await context.Weather.AnyAsync())
        {
            await Task.Run(() =>
            {
                minYear = context.Weather.Min(w => w.RecordedAt);
                maxYear = context.Weather.Max(w => w.RecordedAt);
            });

            return Enumerable.Range(minYear.Year, maxYear.Year - minYear.Year + 1).ToArray();
        }

        return new List<int>();
    }
}