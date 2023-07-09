using DSTest.Domain.Interfaces;
using DSTest.Domain.Models;
using MediatR;

namespace DSTest.Application.Template.Queries;

public class GetTemplateQueryHandler: IRequestHandler<GetTemplateQuery, IEnumerable<TemplateModel>>
{
    private readonly ITemplateRepository _repository;
    
    public GetTemplateQueryHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<TemplateModel>> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.Query();
        
        return entities
            .OrderByDescending(x => x.CreatedAt)
            .Take(request.Take)
            .Select(x => new TemplateModel(x.Value));
    }
}