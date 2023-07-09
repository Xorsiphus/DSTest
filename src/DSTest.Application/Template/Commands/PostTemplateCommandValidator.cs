using FluentValidation;

namespace DSTest.Application.Template.Commands;

public class PostTemplateCommandValidator: AbstractValidator<PostTemplateCommand>
{
    public PostTemplateCommandValidator()
    {
        RuleFor(x => x.TemplateModel.Value).NotEqual("string");
    }
}