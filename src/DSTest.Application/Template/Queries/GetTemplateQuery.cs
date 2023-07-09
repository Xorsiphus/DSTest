using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetTemplateQuery: IRequest<IEnumerable<TemplateModel>>
{
    public int Take { get; init; }
    public int Offset { get; init; }
}