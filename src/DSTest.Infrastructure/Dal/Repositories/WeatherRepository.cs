using DSTest.Domain.Entities;

namespace DSTest.Infrastructure.Dal.Repositories;

public class WeatherRepository : BaseRepository<WeatherEntity>
{
    public WeatherRepository(IServiceProvider scopeFactory) : base(scopeFactory)
    {
    }
}