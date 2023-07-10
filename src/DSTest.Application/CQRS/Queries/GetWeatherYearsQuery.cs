using MediatR;

namespace DSTest.Application.CQRS.Queries;

public class GetWeatherYearsQuery : IRequest<IEnumerable<int>>
{
}