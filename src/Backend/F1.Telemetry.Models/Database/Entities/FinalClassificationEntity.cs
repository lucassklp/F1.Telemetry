using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class FinalClassificationEntity
{
    public int NumCars { get; set; }
    public IEnumerable<FinalClassificationData> ClassificationData { get; set; }
};