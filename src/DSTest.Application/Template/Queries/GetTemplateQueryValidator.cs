using FluentValidation;

namespace DSTest.Application.Template.Queries;

public class GetTemplateQueryValidator: AbstractValidator<GetTemplateQuery>
{
    public GetTemplateQueryValidator()
    {
        RuleFor(x => x.Take).GreaterThan(0);
    }
}