namespace F1.Telemetry.Models.Database.Entities.Data;

public class TyreStintHistoryData
{
    public int EndLap { get; set; } // Lap the tyre usage ends on (255 of current tyre)
    public int TyreActualCompound { get; set; } // Actual tyres used by this driver
    public int TyreVisualCompound { get; set; } // Visual tyres used by this driver
}
