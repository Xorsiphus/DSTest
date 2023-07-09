using DSTest.Domain.Entities;
using DSTest.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DSTest.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(ILogger<WeatherService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<WeatherEntity> ParseData(Stream fileStream, string fileName)
    {
        var result = new List<WeatherEntity>();
        try
        {
            var workbook = new XSSFWorkbook(fileStream);
            if (workbook.Count == 0) return result;

            for (var sheetIdx = 0; sheetIdx < workbook.Count; sheetIdx++)
            {
                var sheet = workbook.GetSheetAt(sheetIdx);
                for (var rowIdx = 4; rowIdx <= sheet.LastRowNum; rowIdx++)
                {
                    var row = sheet.GetRow(rowIdx);
                    if (row == null)
                        continue;

                    var rowResult = new WeatherEntity();
                    for (var cellIdx = 0; cellIdx < row.LastCellNum; cellIdx++)
                    {
                        var cell = row.GetCell(cellIdx);
                        if (cell == null)
                            continue;

                        CollectEntity(rowResult, cell, rowIdx, cellIdx, fileName);
                    }

                    result.Add(rowResult);
                }
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            throw;
        }

        return result;
    }

    private void CollectEntity(WeatherEntity entity, ICell value, int rowId, int cellId, string fileName)
    {
        switch (cellId)
        {
            case 0:
                DateTime.TryParse(GetCellValue(value)?.ToString(), out var res1);
                entity.RecordedAt = res1;
                break;
            case 1:
                TimeOnly.TryParse(GetCellValue(value)?.ToString(), out var res2);
                entity.RecordedAt = DateTime.SpecifyKind(entity.RecordedAt.Add(res2.ToTimeSpan()),
                    DateTimeKind.Utc);
                break;
            case 2:
                float.TryParse(GetCellValue(value)?.ToString(), out var res3);
                entity.Temperature = res3;
                break;
            case 3:
                short.TryParse(GetCellValue(value)?.ToString(), out var res4);
                entity.AirHumidity = res4;
                break;
            case 4:
                float.TryParse(GetCellValue(value)?.ToString(), out var res5);
                entity.TemperatureDelta = res5;
                break;
            case 5:
                short.TryParse(GetCellValue(value)?.ToString(), out var res6);
                entity.AtmospherePressure = res6;
                break;
            case 6:
                entity.WindDirection = GetCellValue(value)?.ToString();
                break;
            case 7:
                short.TryParse(GetCellValue(value)?.ToString(), out var res7);
                entity.WindSpeed = res7;
                break;
            case 8:
                short.TryParse(GetCellValue(value)?.ToString(), out var res8);
                entity.Cloudiness = res8;
                break;
            case 9:
                short.TryParse(GetCellValue(value)?.ToString(), out var res9);
                entity.Height = res9;
                break;
            case 10:
                short.TryParse(GetCellValue(value)?.ToString(), out var res10);
                entity.Vv = res10;
                break;
            case 11:
                entity.WeatherConditions = GetCellValue(value)?.ToString();
                break;
            default:
                _logger.Log(LogLevel.Warning, $"Unhandled cell value at {fileName}: row {rowId} pos {cellId}");
                break;
        }
    }

    private object? GetCellValue(ICell cell)
        => cell.CellType switch
        {
            CellType.String => cell.StringCellValue,
            CellType.Numeric => cell.NumericCellValue,
            CellType.Formula => null,
            CellType.Blank => null,
            CellType.Boolean => null,
            CellType.Error => null,
            CellType.Unknown => null,
            _ => throw new ArgumentOutOfRangeException()
        };
}