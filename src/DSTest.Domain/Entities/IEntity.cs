using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTest.Domain.Entities;

public interface IEntity
{
    [Key] [Column("Id")] public long Id { get; init; }
}