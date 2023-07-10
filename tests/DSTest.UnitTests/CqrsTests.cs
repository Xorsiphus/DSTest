using DSTest.Application.CQRS.Queries;
using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using Moq;

namespace DSTest.UnitTests;

public class CqrsTests
{
    [Fact]
    public void GetTemplateQuery_WhenTakeOne_Success()
    {
        var baseRepository = GetTemplateRepository().Object;

        var request = new GetWeatherDataQuery() { Take = 1 };

        var cut = new GetWeatherDataQueryHandler(baseRepository);

        var actual = cut.Handle(request, new CancellationToken()).Result;

        Assert.Single(actual);
    }

    private static Mock<IBaseRepository<WeatherEntity>> GetTemplateRepository()
    {
        IList<WeatherEntity> db = new List<WeatherEntity>
        {
            new()
            {
                Id = 1,
            },
        };

        var mockDbContext = new Mock<IBaseRepository<WeatherEntity>>();
        mockDbContext.Setup(c => c.Query(1, 0, e => true).Result).Returns(db);
        return mockDbContext;
    }
}