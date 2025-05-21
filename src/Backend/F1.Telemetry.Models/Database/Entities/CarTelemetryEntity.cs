using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class CarTelemetryEntity
{
    public required IEnumerable<TelemetryData> Telemetries { get; set; }
    public int PanelIndex { get; set; } 
    public int PanelIndexSecondaryPlayer { get; set; }
    public int SuggestedGear { get; set; }
}