namespace DSTest.Infrastructure.Dal.Repositories;

public interface IWeatherRepository
{
    Task<IEnumerable<int>> GetYearsInterval();
}