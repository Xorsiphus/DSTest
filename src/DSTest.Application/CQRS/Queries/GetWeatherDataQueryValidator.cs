using FluentValidation;

namespace DSTest.Application.CQRS.Queries;

public class GetWeatherDataQueryValidator: AbstractValidator<GetWeatherDataQuery>
{
    public GetWeatherDataQueryValidator()
    {
        RuleFor(x => x.Take).GreaterThan(0);
        RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
    }
}