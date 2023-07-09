using System.ComponentModel.DataAnnotations.Schema;

namespace DSTest.Domain.Entities;

[Table("Weather")]
public class WeatherEntity : BaseEntity
{
    [Column("RecordedAt")] public DateTime RecordedAt { get; set; }
    [Column("Temperature")] public float Temperature { get; set; }
    [Column("AirHumidity")] public short AirHumidity { get; set; }
    [Column("TemperatureDelta")] public float TemperatureDelta { get; set; }
    [Column("AtmospherePressure")] public short AtmospherePressure { get; set; }
    [Column("WindDirection")] public string? WindDirection { get; set; }
    [Column("WindSpeed")] public short WindSpeed { get; set; }
    [Column("Cloudiness")] public short Cloudiness { get; set; }
    [Column("Height")] public short Height { get; set; }
    [Column("Vv")] public short Vv { get; set; }
    [Column("WeatherConditions")] public string? WeatherConditions { get; set; }


    [Column("CreatedAt")]
    public DateTime CreatedAt
    {
        get => _dateCreated ?? DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        set => _dateCreated = value;
    }

    private DateTime? _dateCreated;
}