using F1.Telemetry.Models.Database.Enums;

namespace F1.Telemetry.Models.Database.Entities.Data;
public class TimeTrialDataSet
{
    public int CarIndex { get; set; } // Index of the car this data relates to
    public int TeamId { get; set; } // Team id - see appendix
    public long LapTimeInMilliseconds { get; set; } // Lap time in milliseconds
    public long Sector1TimeInMilliseconds { get; set; } // Sector 1 time in milliseconds
    public long Sector2TimeInMilliseconds { get; set; } // Sector 2 time in milliseconds
    public long Sector3TimeInMilliseconds { get; set; } // Sector 3 time in milliseconds
    public int TractionControl { get; set; } // 0 = off, 1 = medium, 2 = full
    public GearboxAssist GearboxAssist { get; set; }
    public bool AntiLockBrakes { get; set; } // 0 (off) - 1 (on)
    public bool EqualCarPerformance { get; set; } // 0 = Realistic, 1 = Equal
    public bool CustomSetup { get; set; } // 0 = No, 1 = Yes
    public bool Valid { get; set; } // 0 = invalid, 1 = valid
}
