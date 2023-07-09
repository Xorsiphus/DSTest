using MediatR;
using Microsoft.AspNetCore.Http;

namespace DSTest.Application.Template.Commands;

public class PostWeatherDataCommand: IRequest<Unit>
{
    public IEnumerable<IFormFile>? Files { get; init; }
}