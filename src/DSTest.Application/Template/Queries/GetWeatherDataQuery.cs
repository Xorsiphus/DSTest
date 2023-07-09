using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetWeatherDataQuery : IRequest<IEnumerable<WeatherModel>>
{
    public int Take { get; init; }
    public int Offset { get; init; }
}