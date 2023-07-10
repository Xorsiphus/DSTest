using DSTest.Infrastructure.Dal.Repositories;
using MediatR;

namespace DSTest.Application.CQRS.Queries;

public class GetWeatherYearsQueryHandler : IRequestHandler<GetWeatherYearsQuery, IEnumerable<int>>
{
    private readonly IWeatherRepository _repository;

    public GetWeatherYearsQueryHandler(IWeatherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<int>> Handle(GetWeatherYearsQuery request,
        CancellationToken cancellationToken) => await _repository.GetYearsInterval();
}