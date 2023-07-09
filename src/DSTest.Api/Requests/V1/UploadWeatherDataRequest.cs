namespace DSTest.Api.Requests.V1;

public record UploadWeatherDataRequest(
    IEnumerable<IFormFile> Files);