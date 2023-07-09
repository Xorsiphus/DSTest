using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetWeatherDataQueryHandler : IRequestHandler<GetWeatherDataQuery, IEnumerable<WeatherModel>>
{
    private readonly IBaseRepository<WeatherEntity> _repository;

    public GetWeatherDataQueryHandler(IBaseRepository<WeatherEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WeatherModel>> Handle(GetWeatherDataQuery request,
        CancellationToken cancellationToken)
    {
        var entities = await _repository.Query(request.Take, request.Offset);

        return entities
            .Select(x => new WeatherModel(
                x.Id,
                x.RecordedAt.ToShortDateString(),
                x.RecordedAt.ToShortTimeString(),
                x.Temperature,
                x.AirHumidity,
                x.TemperatureDelta,
                x.AtmospherePressure,
                x.WindDirection,
                x.WindSpeed,
                x.Cloudiness,
                x.Height,
                x.Vv,
                x.WeatherConditions
            ));
    }
}