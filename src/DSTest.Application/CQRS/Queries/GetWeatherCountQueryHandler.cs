using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using MediatR;

namespace DSTest.Application.CQRS.Queries;

public class GetWeatherCountQueryHandler : IRequestHandler<GetWeatherCountQuery, int>
{
    private readonly IBaseRepository<WeatherEntity> _repository;

    public GetWeatherCountQueryHandler(IBaseRepository<WeatherEntity> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(GetWeatherCountQuery request,
        CancellationToken cancellationToken) => await _repository.GetCount(e =>
        (request.Year == 0 || e.RecordedAt.Year.Equals(request.Year)) &&
        (request.Month == 0 || e.RecordedAt.Month.Equals(request.Month))
    );
}