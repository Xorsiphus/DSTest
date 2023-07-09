using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetTemplateQueryHandler: IRequestHandler<GetTemplateQuery, IEnumerable<TemplateModel>>
{
    private readonly IBaseRepository<WeatherEntity> _repository;
    
    public GetTemplateQueryHandler(IBaseRepository<WeatherEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<TemplateModel>> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.Query(request.Take, request.Offset);
        
        return entities
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new TemplateModel(x.Value));
    }
}