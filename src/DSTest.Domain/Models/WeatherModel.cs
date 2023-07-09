namespace DSTest.Domain.Models;

public record WeatherModel(long Id, string Date, string Time, float Temperature, short AirHumidity,
    float TemperatureDelta, short AtmospherePressure, string? WindDirection, short WindSpeed, short Cloudiness,
    short Height, short Vv, string? WeatherConditions);
