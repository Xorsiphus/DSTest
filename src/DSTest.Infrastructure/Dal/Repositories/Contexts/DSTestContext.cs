using DSTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSTest.Infrastructure.Dal.Repositories.Contexts;

public class DsTestContext : DbContext
{
    public DbSet<WeatherEntity> Templates { get; set; }

    public DsTestContext(DbContextOptions<DsTestContext> options) : base(options)
    {
    }
}