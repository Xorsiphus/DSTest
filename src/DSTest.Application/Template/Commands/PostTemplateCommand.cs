using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.Template.Commands;

public class PostTemplateCommand: IRequest<Unit>
{
    public TemplateModel TemplateModel { get; init; }
}