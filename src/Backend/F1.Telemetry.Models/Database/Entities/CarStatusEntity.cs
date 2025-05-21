using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class CarStatusEntity
{
    public IEnumerable<CarStatusData> CarStatusData { get; set; }
}