using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class SessionHistoryEntity
{
    public int CarIdx { get; set; } // Index of the car this lap data relates to
    public int NumLaps { get; set; } // Num laps in the data (including current partial lap)
    public int NumTyreStints { get; set; } // Number of tyre stints in the data
    public int BestLapTimeLapNum { get; set; } // Lap the best lap time was achieved on
    public int BestSector1LapNum { get; set; } // Lap the best Sector 1 time was achieved on
    public int BestSector2LapNum { get; set; } // Lap the best Sector 2 time was achieved on
    public int BestSector3LapNum { get; set; } // Lap the best Sector 3 time was achieved on

    public IEnumerable<LapHistoryData> LapHistoryData { get; set; } // 100 laps of data max

    public IEnumerable<TyreStintHistoryData> TyreStintsHistoryData { get; set; }
}
