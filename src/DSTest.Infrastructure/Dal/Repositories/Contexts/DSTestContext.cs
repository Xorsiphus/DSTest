using DSTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSTest.Infrastructure.Dal.Repositories.Contexts;

public class DsTestContext : DbContext
{
    public DbSet<WeatherEntity> Weather { get; set; }

    public DsTestContext(DbContextOptions<DsTestContext> options) : base(options)
    {
    }
}