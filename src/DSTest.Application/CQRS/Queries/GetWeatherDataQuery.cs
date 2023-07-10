using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.CQRS.Queries;

public class GetWeatherDataQuery : IRequest<IEnumerable<WeatherModel>>
{
    public int Take { get; init; }
    public int Offset { get; init; }
    public int Year { get; init; }
    public int Month { get; init; }
}