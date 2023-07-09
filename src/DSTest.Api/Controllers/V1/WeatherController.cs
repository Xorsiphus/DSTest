using DSTest.Api.Requests.V1;
using DSTest.Api.Responses.V1;
using DSTest.Application.Template.Commands;
using DSTest.Application.Template.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSTest.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class WeatherController : Controller
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> UploadData([FromForm] UploadWeatherDataRequest files)
    {
        await _mediator.Send(new PostWeatherDataCommand() { Files = files.Files });

        return Ok();
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<GetTemplateResponse> GetData([FromQuery] int take, [FromQuery] int offset)
    {
        var models = await _mediator.Send(new GetWeatherDataQuery() { Take = take, Offset = offset });
        var count = await _mediator.Send(new GetWeatherCountQuery());

        return new GetTemplateResponse(models, count);
    }
}