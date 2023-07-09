using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetWeatherYearsQuery : IRequest<IEnumerable<int>>
{
}