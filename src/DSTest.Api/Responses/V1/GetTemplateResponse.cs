using DSTest.Domain.Models;

namespace DSTest.Api.Responses.V1;

public record GetTemplateResponse(IEnumerable<WeatherModel>? Data, int Count);