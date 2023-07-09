using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetWeatherCountQueryHandler : IRequestHandler<GetWeatherCountQuery, int>
{
    private readonly IBaseRepository<WeatherEntity> _repository;

    public GetWeatherCountQueryHandler(IBaseRepository<WeatherEntity> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(GetWeatherCountQuery request,
        CancellationToken cancellationToken) => await _repository.GetCount();
}