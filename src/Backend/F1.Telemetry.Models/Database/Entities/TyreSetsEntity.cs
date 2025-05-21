using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class TyreSetsEntity
{
    public int CarIdx { get; set; }
    
    public IEnumerable<TyreSetData> TyreSetData { get; set; }
    public int FittedIdx { get; set; }
}