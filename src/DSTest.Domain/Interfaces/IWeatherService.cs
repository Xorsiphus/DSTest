using DSTest.Domain.Entities;

namespace DSTest.Domain.Interfaces;

public interface IWeatherService
{
    IEnumerable<WeatherEntity> ParseData(Stream fileStream, string fileName);
}