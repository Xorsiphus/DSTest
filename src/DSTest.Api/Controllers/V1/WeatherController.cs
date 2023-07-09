using DSTest.Api.Requests.V1;
using DSTest.Api.Responses.V1;
using DSTest.Application.Template.Commands;
using DSTest.Application.Template.Queries;
using DSTest.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSTest.Api.Controllers.V1;

[ApiController]
[Route("v1/[controller]")]
public class WeatherController : Controller 
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> UploadData([FromForm]UploadWeatherDataRequest files)
    {
        await _mediator.Send(new PostWeatherDataCommand() { Files = files.Files });
        
        return Ok();
    }

    [HttpPost]
    [Route("get-something")]
    public async Task<IEnumerable<GetTemplateResponse>> GetSomething(GetTemplateRequest request)
    {
        // Basic
        // var models = await _templateService.TemplateQuery(request.Take);
        
        // CQRS
        var models = await _mediator.Send(new GetTemplateQuery() { Take = request.Take });
        
        return models.Select(x => new GetTemplateResponse(x.Value));
    }
}