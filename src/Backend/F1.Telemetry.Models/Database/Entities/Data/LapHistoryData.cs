namespace F1.Telemetry.Models.Database.Entities.Data;

public class LapHistoryData
{
    public long LapTimeInMS { get; set; } // Lap time in milliseconds
    
    public TimeSpan Sector1 { get; set; }
    public TimeSpan Sector2 { get; set; }
    public TimeSpan Sector3 { get; set; }
    
    public int LapValidBitFlags { get; set; } // 0x01 = lap valid, 0x02 = sector 1 valid, 0x04 = sector 2 valid, 0x08 = sector 3 valid
}
