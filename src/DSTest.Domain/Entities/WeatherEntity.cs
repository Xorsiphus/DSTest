using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTest.Domain.Entities;

[Table("Weather")]
public class WeatherEntity
{
    [Key] [Column("Id")] public long Id { get; init; }

    [Column("RecordedAt")] public DateTime RecordedAt { get; init; }
    [Column("Temperature")] public double Temperature { get; init; }
    [Column("AirHumidity")] public short AirHumidity { get; init; }
    [Column("AtmospherePressure")] public short AtmospherePressure { get; init; }
    [Column("WindDirection")] public short WindDirection { get; init; }
    [Column("value")] public string Value { get; init; }
    [Column("WindSpeed")] public short WindSpeed { get; init; }
    [Column("Cloudiness")] public short Cloudiness { get; init; }
    [Column("Height")] public short Height { get; init; }
    [Column("Vv")] public short Vv { get; init; }
    [Column("WeatherConditions")] public short WeatherConditions { get; init; }
    
    [Column("CreatedAt")] public DateTime CreatedAt { get; init; }

    public WeatherEntity(DateTime createdAt, string value)
    {
        CreatedAt = createdAt;
        Value = value;
    }
}