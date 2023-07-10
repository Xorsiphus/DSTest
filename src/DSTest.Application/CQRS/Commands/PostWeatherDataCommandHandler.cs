using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using MediatR;

namespace DSTest.Application.CQRS.Commands;

public class PostWeatherDataCommandHandler : IRequestHandler<PostWeatherDataCommand, Unit>
{
    private readonly IBaseRepository<WeatherEntity> _repository;
    private readonly IWeatherService _weatherService;

    public PostWeatherDataCommandHandler(IBaseRepository<WeatherEntity> repository, IWeatherService weatherService)
    {
        _repository = repository;
        _weatherService = weatherService;
    }

    public async Task<Unit> Handle(PostWeatherDataCommand request, CancellationToken cancellationToken)
    {
        if (request.Files == null) return Unit.Value;
        foreach (var file in request.Files)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            ms.Seek(0, SeekOrigin.Begin);

            await _repository.SaveAll(_weatherService.ParseData(ms, file.FileName));
        }

        return Unit.Value;
    }
}