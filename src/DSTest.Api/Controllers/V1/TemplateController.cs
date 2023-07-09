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
public class TemplateController : Controller
{
    // private readonly ITemplateService _templateService;
    private readonly IMediator _mediator;

    public TemplateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("do-something")]
    public async Task<IActionResult> DoSomething(DoSomethingRequest request)
    {
        // Basic 
        // await _templateService.DoSomething(new TemplateModel(request.Value));
        
        // CQRS
        await _mediator.Send(new PostTemplateCommand() { TemplateModel = new TemplateModel(request.Value) });
        
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