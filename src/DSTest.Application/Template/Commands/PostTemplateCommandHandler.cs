using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using MediatR;

namespace DSTest.Application.Template.Commands;

public class PostTemplateCommandHandler: IRequestHandler<PostTemplateCommand, Unit>
{
    private readonly ITemplateRepository _repository;
    
    public PostTemplateCommandHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Unit> Handle(PostTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = new WeatherEntity(DateTime.UtcNow, request.TemplateModel.Value + "!");

        await _repository.Save(entity);
        
        return Unit.Value;
    }
}