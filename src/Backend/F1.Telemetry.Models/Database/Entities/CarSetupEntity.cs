using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class CarSetupEntity
{
    public IEnumerable<CarSetupData> CarSetups { get; set; }
    public float NextFrontWingValue { get; set; }
};