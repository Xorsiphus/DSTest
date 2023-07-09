using DSTest.Domain.Entities;

namespace DSTest.Domain.Interfaces;

public interface ITemplateRepository
{
    Task Save(WeatherEntity entity);
    Task<IEnumerable<WeatherEntity>> Query();
}