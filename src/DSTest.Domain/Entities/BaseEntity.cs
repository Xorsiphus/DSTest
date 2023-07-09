using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTest.Domain.Entities;

public class BaseEntity : IEntity
{
    [Key] [Column("Id")] public long Id { get; init; }
 
    [Column("CreatedAt")]
    public DateTime CreatedAt
    {
        get => _dateCreated ?? DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        set => _dateCreated = value;
    }

    private DateTime? _dateCreated;
}