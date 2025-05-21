namespace F1.Telemetry.Models.Database.Entities.Data;

public class WeatherForecastSampleData
{
    public int SessionType { get; set; } // 0 = unknown, see appendix
    public int TimeOffset { get; set; } // Time in minutes the forecast is for
    public int Weather { get; set; } // Weather - 0 = clear, 1 = light cloud, 2 = overcast
    // 3 = light rain, 4 = heavy rain, 5 = storm
    public int TrackTemperature { get; set; } // Track temp. in degrees Celsius
    public int TrackTemperatureChange { get; set; } // Track temp. change – 0 = up, 1 = down, 2 = no change
    public int AirTemperature { get; set; } // Air temp. in degrees Celsius
    public int AirTemperatureChange { get; set; } // Air temp. change – 0 = up, 1 = down, 2 = no change
    public int RainPercentage { get; set; } // Rain percentage (0-100)
}
