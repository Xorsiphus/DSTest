using DSTest.Domain.Models;

namespace DSTest.Api.Responses.V1;

public record GetDataResponse(IEnumerable<WeatherModel>? Data, int Count);