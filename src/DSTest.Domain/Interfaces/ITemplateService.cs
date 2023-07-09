using DSTest.Domain.Models;

namespace DSTest.Domain.Services.Interfaces;

public interface ITemplateService
{
    Task DoSomething(TemplateModel templateModel);
    Task<IEnumerable<TemplateModel>> TemplateQuery(int take);
}