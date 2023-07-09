using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using DSTest.Domain.Models;
using DSTest.Domain.Services.Interfaces;

namespace DSTest.Application.Services;

public class TemplateService : ITemplateService
{
    private readonly ITemplateRepository _templateRepository;

    public TemplateService(ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }

    public async Task DoSomething(TemplateModel templateModel)
    {
        var entity = new WeatherEntity(DateTime.UtcNow, templateModel.Value + "!");

        await _templateRepository.Save(entity);
    }

    public async Task<IEnumerable<TemplateModel>> TemplateQuery(int take)
    {
        return (await _templateRepository.Query())
            .OrderByDescending(x => x.CreatedAt)
            .Take(take)
            .Select(entity => new TemplateModel(entity.Value));
    }
}