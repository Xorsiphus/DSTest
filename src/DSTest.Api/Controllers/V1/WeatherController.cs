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
    
    
}