using MediatR;

namespace DSTest.Application.CQRS.Queries;

public class GetWeatherCountQuery : IRequest<int>
{
    public int? Year { get; set; }
    public int? Month { get; set; }
}